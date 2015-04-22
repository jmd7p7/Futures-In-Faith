using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFLibrary
{
    public class PDFPrinter
    {
        public static void PrintPDF(string path)
        {
            string printerPath = "";
            PrintDialog pd = new PrintDialog();
            var result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                printerPath = pd.PrinterSettings.PrinterName;
            }

            //string printer = GetDefaultPrinter();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = path;
            process.StartInfo.Verb = "printto";
            process.StartInfo.Arguments = "\"" + printerPath + "\"";

            process.Start();

            // I have to use this in case of Adobe Reader to close the window
            process.WaitForInputIdle();
            process.Kill();
        }
    }
}
