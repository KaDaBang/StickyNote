using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StickyNote
{
    /// <summary>
    /// 設定保存用クラス
    /// </summary>
    public class Settings
    {   //Noteのプロパティを保存するためのクラス

        //フィールド
        private Size _size;
        private Point _point;
        private int _color;
        private string _title;
        private bool _hyperlink;
        private bool _topmost;
        private string _rtfname;

        /// <summary>
        /// ノートのサイズ
        /// </summary>
        public Size Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// ノートの位置
        /// </summary>
        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        /// <summary>
        /// ノートの色
        /// </summary>
        public int Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// ノートのタイトル
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// ハイパーリンクの有効・無効
        /// </summary>
        public bool HyperLink
        {
            get { return _hyperlink; }
            set { _hyperlink = value; }
        }

        /// <summary>
        /// 最前面表示の有効・無効
        /// </summary>
        public bool TopMost
        {
            get { return _topmost; }
            set { _topmost = value; }
        }

        /// <summary>
        /// RTFのファイル名
        /// </summary>
        public string RtfName
        {
            get { return _rtfname; }
            set { _rtfname = value; }
        }
    }
}
