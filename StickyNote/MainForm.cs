using System;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace StickyNote
{
    public partial class MainForm : Form
    {
        string xmlName;
        bool saveFlag = true;   //ノートを保存するかどうか
        string rtfDir = @".\rtf\note";     //rtfを保存するフォルダのパス
        string rtfName;     //rtfファイルの名前
        bool noteVisible = true;    //ノート表示/非表示の状態を表す
        bool isClosing = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {   //MainFormロード時
            //ノート読み込み
            loadNotes();
        }


        public void newNote()
        {   //ノート新規作成
            NoteForm noteForm = new NoteForm();
            noteForm.Owner = this;
            noteForm.Show();
        }

        public void saveNotes()
        {   //ノートを保存

            //既にあるデータをクリア
            fileDel(@".\Notes");
            fileDel(@".\rtf");


            if (saveFlag == false)
            {
                return;
            }


            //XmlSerializerオブジェクトを作成
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            for (int i = 1; i < Application.OpenForms.Count; i++)
            {   //各NoteFormにループ処理
                //保存用クラスのインスタンス作成
                Settings settings = new Settings();
                NoteForm nf = (NoteForm)Application.OpenForms[i];
                //保存用インスタンスにプロパティセット
                settings.Size = nf.Size;
                settings.Point = nf.Location;
                settings.Color = nf.BackColor.ToArgb();
                settings.Title = nf.getTitle();
                settings.HyperLink = nf.isHyperLink();

                rtfName = rtfDir + i + ".rtf";
                settings.RtfName = rtfName;

                nf.saveRtf(rtfName);

                //ファイル名の作成
                xmlName = @".\Notes\Note" + i + ".config";
                //書き込むファイルを開く
                StreamWriter sw = new StreamWriter(xmlName, false, new UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, settings);
                sw.Close();
            }
        }

        public void loadNotes()
        {   //ノートを読込
            IEnumerable<string> files = Directory.EnumerateFiles(@".\Notes");
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            foreach (string file in files)
            {
                try
                {
                    StreamReader sr = new StreamReader(file, new UTF8Encoding(false));
                    Settings settings = (Settings)serializer.Deserialize(sr);
                    sr.Close();
                    //ノートを作ってプロパティをセット
                    NoteForm nf = new NoteForm();
                    nf.Size = settings.Size;
                    nf.Location = settings.Point;
                    Color color = Color.FromArgb(settings.Color);
                    nf.BackColor = color;
                    nf.setTitle(settings.Title);
                    nf.setHyperLink(settings.HyperLink);
                    nf.loadRtf(settings.RtfName);

                    nf.StartPosition = FormStartPosition.Manual;
                    nf.Owner = this;
                    nf.Show();

                    settings = null;
                }
                catch
                {
                    MessageBox.Show("ノートの読み込みに失敗しました。");
                }
            }
            if (Application.OpenForms.Count == 1)
            {
                newNote();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {   //フォームを閉じる時
            if (isClosing == false)
            {
                DialogResult result = MessageBox.Show("ノートを保存して終了します。",
                    "StickyNote",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button1);

                if (result == DialogResult.OK)
                {
                    //ノートを保存
                    saveNotes();
                    //notifiIconを破棄
                    notifyIcon1.Dispose();
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }

        private void fileDel(string path)
        {
            DirectoryInfo target = new DirectoryInfo(path);
            //ファイル消す
            foreach (FileInfo file in target.GetFiles())
            {
                file.Delete();
            }
        }

        private void visibleToggle()
        {   //ノート表示/非表示の切り替え
            if (noteVisible == true)
            {   //ノート表示中なら非表示に
                for (int i = 1; i < Application.OpenForms.Count; i++)
                {   //開いているNoteFormにループ処理
                    Application.OpenForms[i].Visible = false;
                }
                noteVisible = false;
            }
            else
            {   //ノート非表示中なら表示する
                for (int i = 1; i < Application.OpenForms.Count; i++)
                {   //開いているNoteFormにループ処理
                    Application.OpenForms[i].Visible = true;
                }
                noteVisible = true;
            }

        }

        /********************************************************
        ** contextMenuStrip1
        */
        private void newNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {   //新規作成Item
            newNote();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {   //保存して終了
            isClosing = true;
            saveFlag = true;
            Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {   //削除して終了
            isClosing = true;
            DialogResult result = MessageBox.Show("全てのノートを削除します。",
                "StickyNote",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                saveFlag = false;
                Close();
            }
            else
            {
                return;
            }
        }

        private void noteVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {   //ノート非表示
            visibleToggle();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {   //アイコンダブルクリック時
            visibleToggle();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {   //メニュー展開時
            if (noteVisible == true)
            {   //ノート表示中なら、非表示メニューのチェック外す
                noteVisibleToolStripMenuItem.Checked = false;
            }
            else
            {   //ノート非表示中なら、チェック入れる
                noteVisibleToolStripMenuItem.Checked = true;
            }
        }
    }
}
