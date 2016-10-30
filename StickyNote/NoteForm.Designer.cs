using System.Windows.Forms;

namespace StickyNote
{
    partial class NoteForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.colorChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperlinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plusButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.superRichTextBox1 = new SRichTextBoxLibrary.SuperRichTextBox();
            this.closeButton = new StickyNote.DoubleClickButton();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.titleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleLabel.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.titleLabel.Location = new System.Drawing.Point(23, 4);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(137, 20);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.UseCompatibleTextRendering = true;
            this.titleLabel.DoubleClick += new System.EventHandler(this.titleLabel_DoubleClick);
            this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseDown);
            this.titleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem1,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.toolStripSeparator1,
            this.colorChangeToolStripMenuItem,
            this.hyperlinkToolStripMenuItem,
            this.topMostToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 192);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // cutToolStripMenuItem1
            // 
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Size = new System.Drawing.Size(171, 26);
            this.cutToolStripMenuItem1.Text = "切り取り";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.切り取りToolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.copyToolStripMenuItem.Text = "コピー";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.コピーToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.pasteToolStripMenuItem.Text = "貼り付け";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.貼り付けToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.fontToolStripMenuItem.Text = "フォント";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.フォントToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // colorChangeToolStripMenuItem
            // 
            this.colorChangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YellowToolStripMenuItem,
            this.GreenToolStripMenuItem,
            this.BlueToolStripMenuItem,
            this.PinkToolStripMenuItem,
            this.OrangeToolStripMenuItem,
            this.WhiteToolStripMenuItem});
            this.colorChangeToolStripMenuItem.Name = "colorChangeToolStripMenuItem";
            this.colorChangeToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.colorChangeToolStripMenuItem.Text = "色の変更";
            // 
            // YellowToolStripMenuItem
            // 
            this.YellowToolStripMenuItem.Name = "YellowToolStripMenuItem";
            this.YellowToolStripMenuItem.Size = new System.Drawing.Size(99, 26);
            this.YellowToolStripMenuItem.Text = "黄";
            this.YellowToolStripMenuItem.Click += new System.EventHandler(this.yellowToolStripMenuItem_Click);
            // 
            // GreenToolStripMenuItem
            // 
            this.GreenToolStripMenuItem.Name = "GreenToolStripMenuItem";
            this.GreenToolStripMenuItem.Size = new System.Drawing.Size(99, 26);
            this.GreenToolStripMenuItem.Text = "緑";
            this.GreenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
            // 
            // BlueToolStripMenuItem
            // 
            this.BlueToolStripMenuItem.Name = "BlueToolStripMenuItem";
            this.BlueToolStripMenuItem.Size = new System.Drawing.Size(99, 26);
            this.BlueToolStripMenuItem.Text = "青";
            this.BlueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
            // 
            // PinkToolStripMenuItem
            // 
            this.PinkToolStripMenuItem.Name = "PinkToolStripMenuItem";
            this.PinkToolStripMenuItem.Size = new System.Drawing.Size(99, 26);
            this.PinkToolStripMenuItem.Text = "桃";
            this.PinkToolStripMenuItem.Click += new System.EventHandler(this.pinkToolStripMenuItem_Click);
            // 
            // OrangeToolStripMenuItem
            // 
            this.OrangeToolStripMenuItem.Name = "OrangeToolStripMenuItem";
            this.OrangeToolStripMenuItem.Size = new System.Drawing.Size(99, 26);
            this.OrangeToolStripMenuItem.Text = "橙";
            this.OrangeToolStripMenuItem.Click += new System.EventHandler(this.orangeToolStripMenuItem_Click);
            // 
            // WhiteToolStripMenuItem
            // 
            this.WhiteToolStripMenuItem.Name = "WhiteToolStripMenuItem";
            this.WhiteToolStripMenuItem.Size = new System.Drawing.Size(99, 26);
            this.WhiteToolStripMenuItem.Text = "白";
            this.WhiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
            // 
            // hyperlinkToolStripMenuItem
            // 
            this.hyperlinkToolStripMenuItem.Name = "hyperlinkToolStripMenuItem";
            this.hyperlinkToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.hyperlinkToolStripMenuItem.Text = "ハイパーリンク";
            this.hyperlinkToolStripMenuItem.Click += new System.EventHandler(this.hyperlinkToolStripMenuItem_Click);
            // 
            // topMostToolStripMenuItem
            // 
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.topMostToolStripMenuItem.Text = "最前面に表示";
            this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
            // 
            // plusButton
            // 
            this.plusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.plusButton.FlatAppearance.BorderSize = 0;
            this.plusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plusButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.plusButton.Location = new System.Drawing.Point(4, 4);
            this.plusButton.Margin = new System.Windows.Forms.Padding(0);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(20, 20);
            this.plusButton.TabIndex = 1;
            this.plusButton.TabStop = false;
            this.plusButton.Text = "+";
            this.plusButton.UseCompatibleTextRendering = true;
            this.plusButton.UseVisualStyleBackColor = false;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            this.plusButton.MouseLeave += new System.EventHandler(this.plusButton_MouseLeave);
            this.plusButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.plusButton_MouseMove);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTextBox.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.titleTextBox.Location = new System.Drawing.Point(24, 4);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(136, 27);
            this.titleTextBox.TabIndex = 1;
            this.titleTextBox.TabStop = false;
            this.titleTextBox.Visible = false;
            this.titleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.titleTextBox.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // superRichTextBox1
            // 
            this.superRichTextBox1.AcceptsTab = true;
            this.superRichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.superRichTextBox1.BackColor = this.BackColor;
            this.superRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.superRichTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.superRichTextBox1.DetectUrls = false;
            this.superRichTextBox1.EnableAutoDragDrop = true;
            this.superRichTextBox1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.superRichTextBox1.Location = new System.Drawing.Point(4, 28);
            this.superRichTextBox1.Name = "superRichTextBox1";
            this.superRichTextBox1.Size = new System.Drawing.Size(174, 150);
            this.superRichTextBox1.TabIndex = 0;
            this.superRichTextBox1.Text = "";
            this.superRichTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.superRichTextBox1_LinkClicked);
            this.superRichTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superRichTextBox1_KeyDown);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.closeButton.Location = new System.Drawing.Point(159, 4);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 20);
            this.closeButton.TabIndex = 1;
            this.closeButton.TabStop = false;
            this.closeButton.Text = "×";
            this.closeButton.UseCompatibleTextRendering = true;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.DoubleClick += new System.EventHandler(this.closeButton_DoubleClick);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.closeButton_MouseMove);
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(183, 183);
            this.ControlBox = false;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.superRichTextBox1);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "NoteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.NoteForm_Activated);
            this.Deactivate += new System.EventHandler(this.NoteForm_Deactivate);
            this.BackColorChanged += new System.EventHandler(this.NoteForm_BackColorChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button plusButton;
        private DoubleClickButton closeButton;
        private SRichTextBoxLibrary.SuperRichTextBox superRichTextBox1;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem hyperlinkToolStripMenuItem;
        private ToolStripMenuItem colorChangeToolStripMenuItem;
        private ToolStripMenuItem YellowToolStripMenuItem;
        private ToolStripMenuItem GreenToolStripMenuItem;
        private ToolStripMenuItem BlueToolStripMenuItem;
        private ToolStripMenuItem PinkToolStripMenuItem;
        private ToolStripMenuItem OrangeToolStripMenuItem;
        private ToolStripMenuItem WhiteToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem fontToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem1;
        private ToolStripMenuItem topMostToolStripMenuItem;
    }

    /// <summary>
    /// ダブルクリックボタンのクラス
    /// </summary>
    public class DoubleClickButton : Button
    {
        /// <summary>
        /// ダブルクリックに対応
        /// </summary>
        public DoubleClickButton() : base()
        {
            // Set the style so a double click event occurs.
            SetStyle(ControlStyles.StandardClick |
                ControlStyles.StandardDoubleClick, true);
        }
    }

}

