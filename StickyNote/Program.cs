using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyNote
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //二重起動を禁止する
            //Mutexクラスの作成
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "StickyNote");
            //mutexの所有権を要求する
            if (mutex.WaitOne(0, false) == false)
            {   //既に起動していると判断して終了
                MessageBox.Show("既に起動しています。","StickyNote");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            //mutexを解放する
            mutex.ReleaseMutex();
        }
    }
}
