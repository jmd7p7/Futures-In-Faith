using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIFLibrary;

namespace FuturesInFaith1._4
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

            //First check if this is the user's first time to log in
            if (DBCommunication.IsInitialLogIn())
            {
                InitialSetupForm ISF = new InitialSetupForm();
                ISF.ShowDialog();
            }
            if (!Globals.IsFirstLogin)
            {
                Application.Run(new MainForm());
            }
        }
    }
}
