using System.Windows.Forms;

namespace StickyNote
{
    /// <summary>
    /// 位置を比較する
    /// </summary>
    class LocationComparer : System.Collections.Generic.IComparer<Form>
    {
        /// <summary>
        /// 位置を比較する
        /// </summary>
        /// <param name="x">オブジェクトx</param>
        /// <param name="y">オブジェクトy</param>
        /// <returns>比較結果</returns>
        public int Compare(Form x, Form y)
        {

            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }

            if (((Form)x).Top == ((Form)y).Top)
            {   //xとyのY座標が同じなら
                return x.Left.CompareTo(y.Left);
            }
            else
            {   //Y座標が同じでなければ
                return x.Top.CompareTo(y.Top);
            }

        }

    }
}
