using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyNote
{
    /// <summary>
    /// 印刷プレビューを表示するフォーム
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PrintPreviewForm : Form
    {
        //変数の定義
        bool zooming = false;   //拡大しているかどうか

        /// <summary>
        /// PrintPreviewFormのコンストラクタ
        /// </summary>
        public PrintPreviewForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタのオーバーロード
        /// </summary>
        /// <param name="document">プレビューに表示するPrintDocument</param>
        public PrintPreviewForm(PrintDocument document)
        {
            InitializeComponent();
            this.printPreviewControl1.Document = document;
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {   //PreviewControlをクリックして拡大・縮小
            zoomToggle();
        }

        private void zoomToggle()
        {   //拡大・縮小の切り替え
            if (zooming == false)
            {   //拡大していない場合は拡大
                zooming = true;
                printPreviewControl1.AutoZoom = false;  //オートズームをOFF
                printPreviewControl1.Zoom = 0.8;
            }
            else
            {   //拡大している場合は縮小
                zooming = false;
                printPreviewControl1.AutoZoom = true;
            }
        }

    }
}
