using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StickyNote
{
    public class Settings
    {   //Noteのプロパティを保存するためのクラス

        //フィールド
        private Size _size;
        private Point _point;
        private int _color;
        private string _title;
        private bool _hyperlink;
        private string _rtfname;

        //サイズ
        public Size Size
        {
            get { return _size; }
            set { _size = value; }
        }

        //位置
        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        //色
        public int Color
        {
            get { return _color; }
            set { _color = value; }
        }

        //ノートタイトル
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        //ハイパーリンク
        public bool HyperLink
        {
            get { return _hyperlink; }
            set { _hyperlink = value; }
        }

        //rtfName
        public string RtfName
        {
            get { return _rtfname; }
            set { _rtfname = value; }
        }
    }
}
