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
        private Color yellow = Color.FromArgb(255, 255, 192);
        private Color green = Color.FromArgb(192, 255, 192);
        private Color blue = Color.FromArgb(192, 255, 255);
        private Color pink = Color.FromArgb(255, 192, 255);
        private Color orange = Color.FromArgb(255, 192, 100);
        private Color white = Color.FromArgb(255, 255, 255);

        //印刷用SuperRichTextBox作成
        SRichTextBoxLibrary.SuperRichTextBox printSrtb =
            new SRichTextBoxLibrary.SuperRichTextBox();

        public bool isHyperLink()
        {
            return superRichTextBox1.DetectUrls;
        }
        public void setHyperLink(bool hyper)
        {
            superRichTextBox1.DetectUrls = hyper;
        }

        public NoteForm()
        {
            InitializeComponent();
            superRichTextBox1.BackColor = BackColor;
        }

        private void NoteForm_Load(object sender, EventArgs e)
        {
            setWindowHandle();
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
            titleTextBox.Text = titleLabel.Text;
            titleTextBox.Visible = true;
            titleTextBox.Focus();
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


        /********************************************************
        ** closeButton
        */
        private void closeButton_Click(object sender, EventArgs e)
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
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void superRichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {   //ショートカット
            if (e.KeyCode == Keys.P && e.Control)
            {   //Print [ctrl+P]
                PrintNote();
            }
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

        //FindWindowの宣言
        [DllImport("user32.dll",
                CharSet = CharSet.Auto)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //SetParentの宣言
        [DllImport("user32.dll",
            CharSet = CharSet.Auto)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("User32.Dll")]
        static extern IntPtr GetDesktopWindow();

        private void setWindowHandle()
        {   //ウィンドウハンドルのセット
            IntPtr programManagerHandle = FindWindow(null, "Program Manager");
            if (! programManagerHandle.Equals(IntPtr.Zero))
            {
                SetParent(Handle, programManagerHandle);
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
        {   //ハイパーリンク
            if (isHyperLink() == true)
            {   //ハイパーリンクONならOFF
                setHyperLink(false);
            }
            else
            {   //ハイパーリンクOFFならON
                setHyperLink(true);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {   //メニューストリップ表示時
            if (isHyperLink() == true)
            {   //ハイパーリンクONならチェック
                hyperlinkToolStripMenuItem.Checked = true;
            }
            else
            {   //ハイパーリンクOFFならチェック外す
                hyperlinkToolStripMenuItem.Checked = false;
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
    }
}