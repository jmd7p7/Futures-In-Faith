using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIFLibrary;
using System.IO;

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

            relocateDataBaseFiles();

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
        /*Click once will overwrite the SQLite DB file every time an update is delivered.
         * To avoid this problem, the following method is used.  For a detailed explanation of what this code does
         * from the author of the code, go here: 
         * https://robindotnet.wordpress.com/2009/08/19/where-do-i-put-my-data-to-keep-it-safe-from-clickonce-updates/
         */
        private static void relocateDataBaseFiles()
        {
            string localAppData =
                Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            string userFilePath
              = Path.Combine(localAppData, "FuturesInFaith");

            if (!Directory.Exists(userFilePath))
                Directory.CreateDirectory(userFilePath);

            //if it's not already there, 
            //copy the file from the deployment location to the folder
            string sourceFilePath = Path.Combine(
              System.Windows.Forms.Application.StartupPath, "FuturesInFaith.sqlite");
            string destFilePath = Path.Combine(userFilePath, "FuturesInFaith.sqlite");
            if (!File.Exists(destFilePath))
                File.Copy(sourceFilePath, destFilePath);

            Globals.ConnectionString = "Data Source=" + destFilePath + ";Version=3";

           // @"Data Source=FuturesInFaith.sqlite;Version=3;"
        }
    }
}
