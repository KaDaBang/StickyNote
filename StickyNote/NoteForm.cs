using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace StickyNote
{
    public partial class NoteForm : Form
    {
        //フィールド変数の定義
        Point mousepoint;
        int checkPrint;
        //色
        static Color yellow = Color.FromArgb(255, 255, 192);
        static Color green = Color.FromArgb(192, 255, 192);
        static Color blue = Color.FromArgb(192, 255, 255);
        static Color pink = Color.FromArgb(255, 192, 255);
        static Color orange = Color.FromArgb(255, 192, 100);
        static Color white = Color.FromArgb(255, 255, 255);

        static Color ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));

        static Color deActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));

        
        public bool isHyperLink
        {   //ハイパーリンクのON/OFF
            get { return superRichTextBox1.DetectUrls; }
            set { superRichTextBox1.DetectUrls = value; }
        }

        //印刷用SuperRichTextBox作成
        SRichTextBoxLibrary.SuperRichTextBox printSrtb =
            new SRichTextBoxLibrary.SuperRichTextBox();

        public NoteForm()
        {
            InitializeComponent();
            superRichTextBox1.BackColor = BackColor;
        }

        private void NoteForm_Load(object sender, EventArgs e)
        {
            // setWindowHandle();
        }

        private void NoteForm_Activated(object sender, EventArgs e)
        {   //アクティブになったら、タイトルバーの色を濃くする
            titleLabel.BackColor = ActiveColor;
            plusButton.BackColor = ActiveColor;
            closeButton.BackColor = ActiveColor;
            //テキストボックスにフォーカスする
            superRichTextBox1.Focus();
        }

        private void NoteForm_Deactivate(object sender, EventArgs e)
        {   //非アクティブになったら、タイトルバーの色を薄くする
            titleLabel.BackColor = deActiveColor;
            plusButton.BackColor = deActiveColor;
            closeButton.BackColor = deActiveColor;
            //テキストボックスにフォーカスする
            superRichTextBox1.Focus();
        }


        /********************************************************
        ** titleLabel
        */
        public string getTitle()
        {
            return titleLabel.Text;
        }

        public void setTitle(string title)
        {
            titleLabel.Text = title;
        }

        //タイトルラベルドラッグで、ノートを移動
        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {   //左クリック時に位置を記憶
            if(e.Button == MouseButtons.Left)
            {
                mousepoint = new Point(e.X, e.Y);
            }
        }

        private void titleLabel_MouseMove(object sender, MouseEventArgs e)
        {   //ドラッグ時に位置を変更
            if(e.Button == MouseButtons.Left)
            {
                Left += e.X - mousepoint.X;
                Top += e.Y - mousepoint.Y;
            }
        }

        private void titleLabel_DoubleClick(object sender, EventArgs e)
        {   //タイトルラベルをダブルクリックでタイトル編集
            titleEdit();
        }


        /********************************************************
        ** titleTextBox
        */
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {   //Enterが押されたら
                superRichTextBox1.Focus();
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            titleLabel.Text = titleTextBox.Text;
            titleTextBox.Visible = false;
        }

        private void titleEdit()
        {
            titleTextBox.Text = titleLabel.Text;
            titleTextBox.Visible = true;
            titleTextBox.Focus();
        }


        /********************************************************
        ** closeButton
        */
        private void closeButton_DoubleClick(object sender, EventArgs e)
        {   //closeButtonでノートを閉じる
            Close();
        }


        /********************************************************
        ** plusButton
        */
        private void plusButton_Click(object sender, EventArgs e)
        {   //plusButtonで新規ノート作成
            ((MainForm)Owner).newNote();
        }


        /********************************************************
        ** superRichTextBox
        */
        private void NoteForm_BackColorChanged(object sender, EventArgs e)
        {   //バックカラーが変更されたとき
            //テキストボックスの色を変更
            superRichTextBox1.BackColor = BackColor;
        }

        public void saveRtf(string filename)
        {   
            superRichTextBox1.SaveFile(filename);
        }

        public void loadRtf(string filename)
        {
            superRichTextBox1.LoadFile(filename);
        }

        private void superRichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {   //リンククリック時
            try
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
            catch
            {   //リンクオープンに失敗した時
                MessageBox.Show("リンク先を開くことができませんでした。");
            }
        }


        /********************************************************
        ** ショートカットの定義
        */
        private void superRichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {   //ショートカット
            if (e.KeyCode == Keys.P && e.Control && !e.Shift)
            {   //Print [ctrl+P]
                PrintNote();
            }

            if (e.KeyCode == Keys.N && e.Control && !e.Shift)
            {   //新しいノート
                ((MainForm)Owner).newNote();
            }

            if (e.KeyCode == Keys.T && e.Control && e.Shift)
            {   //タイトル編集
                titleEdit();
            }

            if (e.KeyCode == Keys.H && e.Control && !e.Shift)
            {   //ハイパーリンクのON/OFF
                toggleHyperLink();
            }

            if (e.KeyCode == Keys.OemPeriod && e.Control && !e.Shift)
            {   //次のノート
                changeActiveNote(this, true);
            }
            if (e.KeyCode == Keys.Oemcomma && e.Control && !e.Shift)
            {   //前のノート
                changeActiveNote(this, false);
            }

        }

        //アクティブなノートの切り替え
        private void changeActiveNote(Form nowNote, Boolean go)
        {   //nowNote:現在のノート　go:次のノート=true 前のノート=false

            Form targetNote;    //切り替え先のノート
            if (go)
            {   //go=trueなら
                if ((checkNoteId(nowNote) + 1) > Application.OpenForms.Count - 1)
                {   //ノートの数がオーバーしていたら一つ目のノート
                    targetNote = Application.OpenForms[1];
                }
                else
                {   //オーバーしていなければ次のノート
                    targetNote = Application.OpenForms[checkNoteId(nowNote) + 1];
                }
            }
            else
            {   //go=falseなら
                if ((checkNoteId(nowNote) - 1) <= 0)
                {   //ノートのidが０以下なら最後のノート
                    targetNote = Application.OpenForms[Application.OpenForms.Count - 1];
                }
                else
                {   //1以上なら前のノート
                    targetNote = Application.OpenForms[checkNoteId(nowNote) - 1];
                }
            }
            //targetNoteをアクティブにする
            targetNote.Activate();
        }

        //アクティブなノートの、openForms上のIDを調べる
        private int checkNoteId(Form nowNote)
        {   //openFormsをループして、nowNoteと等しいものを見つける。
            for (int i = 0; i <= Application.OpenForms.Count; i++)
            {
                if (nowNote == Application.OpenForms[i])
                {
                    return i;
                }
            }
            return -1;
        }

        /********************************************************
        ** ウインドウサイズ変更
        */
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WindowsConst.WM_NCHITTEST)
            {            // 0x84 : WM_NCHITTEST
                Point point = PointToClient(new Point(m.LParam.ToInt32() % 65536, m.LParam.ToInt32() / 65536));

                if (point.X > ClientRectangle.Right ||
                    point.X < ClientRectangle.Left ||
                    point.Y < ClientRectangle.Top ||
                    point.Y > ClientRectangle.Bottom)
                {
                    return;
                }

                if (point.X < ClientRectangle.Left + 5)
                {
                    if (point.Y < ClientRectangle.Top + 5)
                    {
                        m.Result = (IntPtr)WindowsConst.HTTOPLEFT;
                        return;
                    }
                    if (point.Y > ClientRectangle.Bottom - 5)
                    {
                        m.Result = (IntPtr)WindowsConst.HTBOTTOMLEFT;
                        return;
                    }
                    m.Result = (IntPtr)WindowsConst.HTLEFT;
                    return;
                }
                if (point.X > ClientRectangle.Right - 5)
                {
                    if (point.Y < ClientRectangle.Top + 5)
                    {
                        m.Result = (IntPtr)WindowsConst.HTTOPRIGHT;
                        return;
                    }
                    if (point.Y > ClientRectangle.Bottom - 5)
                    {
                        m.Result = (IntPtr)WindowsConst.HTBOTTOMRIGHT;
                        return;
                    }
                    m.Result = (IntPtr)WindowsConst.HTRIGHT;
                    return;
                }
                if (point.Y < ClientRectangle.Top + 5)
                {
                    m.Result = (IntPtr)WindowsConst.HTTOP;
                    return;
                }
                if (point.Y > ClientRectangle.Bottom - 5)
                {
                    m.Result = (IntPtr)WindowsConst.HTBOTTOM;
                    return;
                }
            }
        }

        /********************************************************
        ** contextMenuStrip1
        */

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {   //黄
            this.BackColor = yellow;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {   //緑
            this.BackColor = green;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {   //青
            this.BackColor = blue;
        }

        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {   //桃
            this.BackColor = pink;
        }

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {   //橙
            this.BackColor = orange;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {   //白
            this.BackColor = white;
        }

        private void hyperlinkToolStripMenuItem_Click(object sender, EventArgs e)
        {   //ハイパーリンクのON/OFF
            toggleHyperLink();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {   //メニューストリップ表示時
            if (isHyperLink == true)
            {   //ハイパーリンクONならチェック
                hyperlinkToolStripMenuItem.Checked = true;
            }
            else
            {   //ハイパーリンクOFFならチェック外す
                hyperlinkToolStripMenuItem.Checked = false;
            }
        }

        private void toggleHyperLink()
        {   //ハイパーリンクのON/OFF
            if (isHyperLink == true)
            {   //ハイパーリンクONならOFF
                isHyperLink = false;
            }
            else
            {   //ハイパーリンクOFFならON
                isHyperLink = true;
            }
        }

        /********************************************************
        ** 印刷
        */

        public void PrintNote()
        {   //ノートを印刷する
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printSrtb.Text = titleLabel.Text + "\n\n";
                printSrtb.SelectAll();
                printSrtb.SelectionFont =
                    new Font(printSrtb.SelectionFont.FontFamily,15, printSrtb.SelectionFont.Style);
                printSrtb.SelectionStart = printSrtb.TextLength;
                printSrtb.SelectedRtf = superRichTextBox1.Rtf;
                printDocument1.Print();
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Print the content of RichTextBox. Store the last character printed.
            checkPrint = printSrtb.Print(checkPrint, printSrtb.TextLength, e);

            // Check for more pages
            if (checkPrint < printSrtb.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void NoteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((MainForm)Owner).noteCheck();
        }
    }
}