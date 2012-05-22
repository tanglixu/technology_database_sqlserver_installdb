using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace My.Tools.InstallDB
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool dlgInstall = true;
            if (args.CountIf() == 2 && args[0] == "-auto")
            {
                string dataBaseBakFile = args[1];
                if (File.Exists(dataBaseBakFile))
                    if (FrmLogin.InstallDBAuto(dataBaseBakFile))
                        dlgInstall = false;
            }
            if(dlgInstall)
                Application.Run(new FrmLogin());
        }
    }
}
