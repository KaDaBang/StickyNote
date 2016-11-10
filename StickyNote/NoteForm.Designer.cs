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
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.closeButton = new StickyNote.DoubleClickButton();
            this.superRichTextBox1 = new StickyNote.SuperRichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.titleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.UseCompatibleTextRendering = true;
            this.titleLabel.DoubleClick += new System.EventHandler(this.titleLabel_DoubleClick);
            this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseDown);
            this.titleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseMove);
            this.titleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseUp);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem1,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.colorChangeToolStripMenuItem,
            this.hyperlinkToolStripMenuItem,
            this.topMostToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // cutToolStripMenuItem1
            // 
            resources.ApplyResources(this.cutToolStripMenuItem1, "cutToolStripMenuItem1");
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.切り取りToolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem
            // 
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.コピーToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.貼り付けToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            resources.ApplyResources(this.fontToolStripMenuItem, "fontToolStripMenuItem");
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.フォントToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // printToolStripMenuItem
            // 
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem1,
            this.printPreviewToolStripMenuItem,
            this.pageSetupToolStripMenuItem});
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            // 
            // printToolStripMenuItem1
            // 
            resources.ApplyResources(this.printToolStripMenuItem1, "printToolStripMenuItem1");
            this.printToolStripMenuItem1.Name = "printToolStripMenuItem1";
            this.printToolStripMenuItem1.Click += new System.EventHandler(this.printToolStripMenuItem1_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            resources.ApplyResources(this.printPreviewToolStripMenuItem, "printPreviewToolStripMenuItem");
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // pageSetupToolStripMenuItem
            // 
            resources.ApplyResources(this.pageSetupToolStripMenuItem, "pageSetupToolStripMenuItem");
            this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            this.pageSetupToolStripMenuItem.Click += new System.EventHandler(this.pageSetupToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // colorChangeToolStripMenuItem
            // 
            resources.ApplyResources(this.colorChangeToolStripMenuItem, "colorChangeToolStripMenuItem");
            this.colorChangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YellowToolStripMenuItem,
            this.GreenToolStripMenuItem,
            this.BlueToolStripMenuItem,
            this.PinkToolStripMenuItem,
            this.OrangeToolStripMenuItem,
            this.WhiteToolStripMenuItem});
            this.colorChangeToolStripMenuItem.Name = "colorChangeToolStripMenuItem";
            // 
            // YellowToolStripMenuItem
            // 
            resources.ApplyResources(this.YellowToolStripMenuItem, "YellowToolStripMenuItem");
            this.YellowToolStripMenuItem.Name = "YellowToolStripMenuItem";
            this.YellowToolStripMenuItem.Click += new System.EventHandler(this.yellowToolStripMenuItem_Click);
            // 
            // GreenToolStripMenuItem
            // 
            resources.ApplyResources(this.GreenToolStripMenuItem, "GreenToolStripMenuItem");
            this.GreenToolStripMenuItem.Name = "GreenToolStripMenuItem";
            this.GreenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
            // 
            // BlueToolStripMenuItem
            // 
            resources.ApplyResources(this.BlueToolStripMenuItem, "BlueToolStripMenuItem");
            this.BlueToolStripMenuItem.Name = "BlueToolStripMenuItem";
            this.BlueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
            // 
            // PinkToolStripMenuItem
            // 
            resources.ApplyResources(this.PinkToolStripMenuItem, "PinkToolStripMenuItem");
            this.PinkToolStripMenuItem.Name = "PinkToolStripMenuItem";
            this.PinkToolStripMenuItem.Click += new System.EventHandler(this.pinkToolStripMenuItem_Click);
            // 
            // OrangeToolStripMenuItem
            // 
            resources.ApplyResources(this.OrangeToolStripMenuItem, "OrangeToolStripMenuItem");
            this.OrangeToolStripMenuItem.Name = "OrangeToolStripMenuItem";
            this.OrangeToolStripMenuItem.Click += new System.EventHandler(this.orangeToolStripMenuItem_Click);
            // 
            // WhiteToolStripMenuItem
            // 
            resources.ApplyResources(this.WhiteToolStripMenuItem, "WhiteToolStripMenuItem");
            this.WhiteToolStripMenuItem.Name = "WhiteToolStripMenuItem";
            this.WhiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
            // 
            // hyperlinkToolStripMenuItem
            // 
            resources.ApplyResources(this.hyperlinkToolStripMenuItem, "hyperlinkToolStripMenuItem");
            this.hyperlinkToolStripMenuItem.Name = "hyperlinkToolStripMenuItem";
            this.hyperlinkToolStripMenuItem.Click += new System.EventHandler(this.hyperlinkToolStripMenuItem_Click);
            // 
            // topMostToolStripMenuItem
            // 
            resources.ApplyResources(this.topMostToolStripMenuItem, "topMostToolStripMenuItem");
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
            // 
            // plusButton
            // 
            resources.ApplyResources(this.plusButton, "plusButton");
            this.plusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.plusButton.FlatAppearance.BorderSize = 0;
            this.plusButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.plusButton.Name = "plusButton";
            this.plusButton.TabStop = false;
            this.plusButton.UseCompatibleTextRendering = true;
            this.plusButton.UseVisualStyleBackColor = false;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            this.plusButton.MouseLeave += new System.EventHandler(this.plusButton_MouseLeave);
            this.plusButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.plusButton_MouseMove);
            // 
            // titleTextBox
            // 
            resources.ApplyResources(this.titleTextBox, "titleTextBox");
            this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.TabStop = false;
            this.titleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.titleTextBox.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.closeButton.Name = "closeButton";
            this.closeButton.TabStop = false;
            this.closeButton.UseCompatibleTextRendering = true;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.DoubleClick += new System.EventHandler(this.closeButton_DoubleClick);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.closeButton_MouseMove);
            // 
            // superRichTextBox1
            // 
            this.superRichTextBox1.AcceptsTab = true;
            resources.ApplyResources(this.superRichTextBox1, "superRichTextBox1");
            this.superRichTextBox1.BackColor = this.BackColor;
            this.superRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.superRichTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.superRichTextBox1.DetectUrls = false;
            this.superRichTextBox1.EnableAutoDragDrop = true;
            this.superRichTextBox1.Name = "superRichTextBox1";
            this.superRichTextBox1.TabStop = false;
            this.superRichTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.superRichTextBox1_LinkClicked);
            // 
            // NoteForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.superRichTextBox1);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.NoteForm_Activated);
            this.Deactivate += new System.EventHandler(this.NoteForm_Deactivate);
            this.Load += new System.EventHandler(this.NoteForm_Load);
            this.ResizeEnd += new System.EventHandler(this.NoteForm_ResizeEnd);
            this.BackColorChanged += new System.EventHandler(this.NoteForm_BackColorChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoteForm_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label titleLabel;
        private Button plusButton;
        private DoubleClickButton closeButton;
        private SuperRichTextBox superRichTextBox1;
        private TextBox titleTextBox;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem hyperlinkToolStripMenuItem;
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
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem1;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripMenuItem pageSetupToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
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

