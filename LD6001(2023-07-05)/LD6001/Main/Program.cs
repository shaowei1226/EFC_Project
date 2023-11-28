using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
             bool isFirstOpen;

             Mutex mutex = new Mutex(false, Application.ProductName, out isFirstOpen);

             if (isFirstOpen)
             {
                  Application.EnableVisualStyles();
                  Application.SetCompatibleTextRenderingDefault(false);
                  Application.Run(new TForm_Main());
             }
             else
             {
                  MessageBox.Show("重複開啟!");
             }

             mutex.Dispose();
        }
    }
}
