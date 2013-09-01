using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.UI.Forms;
using LJH.Inventory.UI.Applications.WaiMao;

namespace InventoryApplication
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!LJH.GeneralLibrary.SingleInstance.ExistsProcess())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form frm = new FrmMain();
                Application.Run(frm);
            }
            else
            {
                LJH.GeneralLibrary.SingleInstance.ShowSingleProcess();
            }
        }
    }
}
