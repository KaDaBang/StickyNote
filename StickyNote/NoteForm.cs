using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Permissions;

namespace StickyNote
{
    /// <summary>
    /// ノートフォームクラス
    /// </summary>
    public partial class NoteForm : Form
    {
        //フィールド変数の定義
        private Point mousepoint;
        //色
        private static Color yellow = Color.FromArgb(255, 255, 192);
        private static Color green = Color.FromArgb(192, 255, 192);
        private static Color blue = Color.FromArgb(192, 255, 255);
        private static Color pink = Color.FromArgb(255, 192, 255);
        private static Color orange = Color.FromArgb(255, 192, 100);
        private static Color white = Color.FromArgb(255, 255, 255);

        private static Color ActiveColor = Color.FromArgb(255, 224, 224, 224);
        private static Color deActiveColor = Color.FromArgb(100, 224, 224, 224);

        private static Color colorButtonNotActive = Color.FromArgb(0, 200, 200, 200);

        private static int grid = 5;

        //印刷用テキストボックスを作成
        private SuperRichTextBox printSrtb = new SuperRichTextBox();

        /// <summary>
        /// ノートのタイトル
        /// </summary>
        public string title
        {   //タイトル
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }

        /// <summary>
        /// SuperRichTextBox
        /// </summary>
        public SuperRichTextBox sRichTextBox
        {
            get { return superRichTextBox1; }
        }

        /// <summary>
        /// ハイパーリンクのON/OFF取得・設定
        /// </summary>
        public bool isHyperLink
        {
            get { return superRichTextBox1.DetectUrls; }
            set { superRichTextBox1.DetectUrls = value; }
        }
        /// <summary>
        /// 最前面表示のON/OFF取得・設定
        /// </summary>
        public bool isTopMost
        {
            get { return TopMost; }
            set { TopMost = value; }
        }

        /// <summary>
        /// ノートフォームのコンストラクタ
        /// </summary>
        public NoteForm()
        {
            InitializeComponent();
        }

        private void NoteForm_Load(object sender, EventArgs e)
        {
            superRichTextBox1.BackColor = BackColor;
            fitGrid();
        }

        private void NoteForm_Activated(object sender, EventArgs e)
        {   //アクティブになったら、タイトルバーの色を濃くする
            titleLabel.BackColor = ActiveColor;
            plusButton.BackColor = ActiveColor;
            closeButton.BackColor = ActiveColor;
            //ボタンのテキストを表示
            plusButton.ForeColor = SystemColors.ControlDark;
            closeButton.ForeColor = SystemColors.ControlDark;
            //テキストボックスにフォーカスする
            superRichTextBox1.Select();
        }

        private void NoteForm_Deactivate(object sender, EventArgs e)
        {   //非アクティブになったら、タイトルバーの色を薄くする
            titleLabel.BackColor = deActiveColor;
            plusButton.BackColor = deActiveColor;
            closeButton.BackColor = deActiveColor;
            //ボタンのテキスト薄く
            plusButton.ForeColor = colorButtonNotActive;
            closeButton.ForeColor = colorButtonNotActive;
            //テキストボックスにフォーカスする
            superRichTextBox1.Select();
        }

        //タイトルラベルドラッグで、ノートを移動
        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {   //左クリック時に位置を記憶
            if (e.Button == MouseButtons.Left)
            {
                mousepoint = new Point(e.X, e.Y);
            }
        }

        private void titleLabel_MouseMove(object sender, MouseEventArgs e)
        {   //ドラッグ時に位置を変更
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - mousepoint.X;
                Top += e.Y - mousepoint.Y;
            }
        }

        private void titleLabel_DoubleClick(object sender, EventArgs e)
        {   //タイトルラベルをダブルクリックでタイトル編集
            titleEdit();
        }

        private void titleLabel_MouseUp(object sender, MouseEventArgs e)
        {   //位置変更が終わったとき
            fitGrid();
        }

        /********************************************************
        ** titleTextBox
        */
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {   //Enterが押されたら
                superRichTextBox1.Select();
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            title = titleTextBox.Text;
            titleTextBox.Visible = false;
        }

        private void titleEdit()
        {
            titleTextBox.Text = title;
            titleTextBox.Visible = true;
            titleTextBox.Select();
        }


        /********************************************************
        ** closeButton
        */
        private void closeButton_DoubleClick(object sender, EventArgs e)
        {   //closeButtonでノートを閉じる
            ((MainForm)Owner).noteClose(this);
        }

        private void closeButton_MouseMove(object sender, MouseEventArgs e)
        {   //マウスが上に来たら
            closeButton.ForeColor = SystemColors.ControlDarkDark;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {   //マウスが離れたら
            if (Form.ActiveForm != this)
            {
                closeButton.ForeColor = colorButtonNotActive;
            }
            else
            {
                closeButton.ForeColor = SystemColors.ControlDark;
            }
        }

        /********************************************************
        ** plusButton
        */
        private void plusButton_Click(object sender, EventArgs e)
        {   //plusButtonで新規ノート作成
            ((MainForm)Owner).newNote();
        }

        private void plusButton_MouseMove(object sender, MouseEventArgs e)
        {   //マウスが上に来たら
            plusButton.ForeColor = SystemColors.ControlDarkDark;
        }

        private void plusButton_MouseLeave(object sender, EventArgs e)
        {   //マウスが離れたら
            if (Form.ActiveForm != this)
            {
                plusButton.ForeColor = colorButtonNotActive;
            }
            else
            {
                plusButton.ForeColor = SystemColors.ControlDark;
            }
        }

        /********************************************************
        ** superRichTextBox
        */
        private void NoteForm_BackColorChanged(object sender, EventArgs e)
        {   //バックカラーが変更されたとき
            //テキストボックスの色を変更
            superRichTextBox1.BackColor = BackColor;
        }

        /// <summary>
        /// RTFを保存する
        /// </summary>
        /// <param name="filename">保存するファイル名</param>
        public void saveRtf(string filename)
        {
            superRichTextBox1.SaveFile(filename);
        }

        /// <summary>
        /// RTFを読み込む
        /// </summary>
        /// <param name="filename">読み込むファイル名</param>
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
        private void NoteForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && e.Control && !e.Shift && !e.Alt)
            {   //新しいノート
                ((MainForm)Owner).newNote();
            }

            if (e.KeyCode == Keys.T && e.Control && e.Shift && !e.Alt)
            {   //タイトル編集
                titleEdit();
            }

            if (e.KeyCode == Keys.OemPeriod && e.Control && !e.Shift && !e.Alt)
            {   //次のノート
                ((MainForm)Owner).changeActiveNote(true);
            }

            if (e.KeyCode == Keys.Oemcomma && e.Control && !e.Shift && !e.Alt)
            {   //前のノート
                ((MainForm)Owner).changeActiveNote(false);
            }

            if (e.KeyCode == Keys.F4 && e.Alt )
            {   //ノート閉じる
                ((MainForm)Owner).noteClose(this);
            }
        }

        /********************************************************
        ** ウインドウサイズ変更
        */
        /// <summary>
        /// ヒットテストオーバーライド
        /// </summary>
        /// <param name="m">メッセージ</param>
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

        private void NoteForm_ResizeEnd(object sender, EventArgs e)
        {   //サイズ変更が終わったとき
            fitGrid();
        }

        /********************************************************
        ** contextMenuStrip1
        */
        private void 切り取りToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            superRichTextBox1.Cut();
        }

        private void コピーToolStripMenuItem_Click(object sender, EventArgs e)
        {
            superRichTextBox1.Copy();
        }

        private void 貼り付けToolStripMenuItem_Click(object sender, EventArgs e)
        {
            superRichTextBox1.Paste();
        }

        private void フォントToolStripMenuItem_Click(object sender, EventArgs e)
        {
            superRichTextBox1.showFontDialog();
        }
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
        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {   //最前面表示のON/OFF
            toggleTopMost();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {   //印刷
            prePrint();
            printSrtb.print();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {   //印刷プレビュー
            prePrint();
            printSrtb.showPrintPreview();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {   //ページ設定
            printSrtb.printPageSetup();
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

            if (TopMost == true)
            {   //最前面表示がONならチェック
                topMostToolStripMenuItem.Checked = true;
            }
            else
            {   //最前面表示がOFFならチェック
                topMostToolStripMenuItem.Checked = false;
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
        private void toggleTopMost()
        {   //最前面表示のON/OFF
            if (TopMost == true)
            {   //最前面表示がONならOFFに
                TopMost = false;
            }
            else
            {   //最前面表示がOFFならONに
                TopMost = true;
            }

        }

        /// <summary>
        /// 「閉じる」を無効化する
        /// </summary>
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.Demand,
                Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;

                return cp;
            }
        }

        /// <summary>
        /// ノートの印刷準備を行う。
        /// </summary>
        public void prePrint()
        {
            printSrtb.Text = title + "\n\n";
            printSrtb.SelectAll();
            printSrtb.SelectionFont =
                new Font(printSrtb.SelectionFont.FontFamily, 18, printSrtb.SelectionFont.Style);
            printSrtb.SelectionStart = printSrtb.TextLength;
            printSrtb.SelectedRtf = sRichTextBox.Rtf;
        }

        /// <summary>
        /// 値を四捨五入します
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="decimals">小数部桁数</param>
        /// <param name="mode">丸める方法</param>
        /// <returns>丸められた値</returns>
        private double Round(double value, int decimals,
            MidpointRounding mode)
        {
            // 小数部桁数の10の累乗を取得
            double pow = Math.Pow(10, decimals);

            return Math.Round(value * pow, mode) / pow;
        }

        private void fitGrid()
        {   //サイズと位置をグリッドに合わせる
            if (Height % grid == 0 && Width % grid == 0 && Left % grid == 0 && Top % grid == 0)
            {   //すでにグリッドに従っている場合
                return;
            }

            if (Height % grid != 0)
            {   //高さ
                Height = (int)Round(Height * 2, -1, MidpointRounding.AwayFromZero) / 2;
            }

            if (Width % grid != 0)
            {   //幅
                Width = (int)Round(Width * 2, -1, MidpointRounding.AwayFromZero) / 2;
            }

            if (Left % grid != 0)
            {   //x座標
                Left = (int)Round(Left * 2, -1, MidpointRounding.AwayFromZero) / 2;
            }

            if (Top % grid != 0)
            {   //y座標
                Top = (int)Round(Top * 2, -1, MidpointRounding.AwayFromZero) / 2;
            }


        }

        private void moveWindow()
        {   //キーボードでウィンドウを移動
            
        }

        private void changeSize()
        {   //キーボードでサイズ変更

        }

    }
}