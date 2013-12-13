using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLBV_normal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DangkyForm frmDangky = new DangkyForm();
            frmDangky.Show();
            //MainForm frmMain = new MainForm();
            //frmMain.Show();
            Application.Run();
        }
    }
}
