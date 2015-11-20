using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FIFLibrary
{
    public static class Globals
    {
        public static int seedMultiplier = 2;
        public static int ID = 1000000;
        //public static string ConnectionString = @"Data Source=C:\Users\Jonathan\Documents\DEV\FIF\Projects\FIF1.4\FIF1.4\FuturesInFaith1.4\FuturesInFaith.sqlite;Version=3;";
        //public static string ConnectionString = @"Data Source=C:\Users\Jonathan\Documents\Software Development\Futures In Faith\Visual Studio Projects\FuturesInFaith1.4\FuturesInFaith1.4\FuturesInFaith1.4\FuturesInFaith.sqlite;Version=3;";
        public static string ConnectionString = @"Data Source=FuturesInFaith.sqlite;Version=3;";
        public static string EmailMessage;
        public static List<string> EmailMessageVariables;
        public static string EmailSubject;
        public static List<string> EmailSubjectVariables;
        public static bool rebindOnMainForm;
        public static bool rebindYouthOnMainForm;
        public static bool IsFirstLogin;
        


        public static List<Investor2> GlobalInvestors;
        public static List<Investment2> GlobalInvestments;
        public static List<Youth> GlobalYouth;
        public static List<int> GlobalCertificateNumbers;
        public static string GlobalCurrentCertificatePrefix;
        public static List<string> GlobalCertificateNumbersToDelete;

        //Default values that can be changed by the user
        public static string DefaultPaymentType = "check";
        public static string DefaultCreditToType = "general fund";
        public static int DefaultInvestmentAmount = 40;
        public static string SaveFilePath = @"C:\Users\Jonathan\Desktop\temp files\FIF\";
        public static DateTime ProgramStartDate = Convert.ToDateTime("1/1/2010"); //This will be initialized by the global user settings
        public static DateTime ProgramEndDate;  //This will be initialized by the global user settings
        public static string AdminEmail;
        public static string AdminPassword;

        //Global methods

        public static void InitializeCertificateNumbers()
        {
            GlobalCertificateNumbers = new List<int>();
            bool buildNewListFromScratch = false;
            int maxID;
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    conn.Open();
                    string IsInitialCommandString = "SELECT COUNT(CertificateNumberID) FROM CertificateNumber";
                    
                    using (SQLiteCommand IsInitialCommand = new SQLiteCommand(IsInitialCommandString, conn))
                    {
                        using (SQLiteDataReader rdr = IsInitialCommand.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                if (rdr.GetInt32(0) == 0) // If true there are no certificate numbers in the DB, build a list from scratch
                                {
                                    buildNewListFromScratch = true;
                                }
                            }
                        }
                    }

                    if(buildNewListFromScratch == true)
                    {
                        GlobalCurrentCertificatePrefix = "A";
                        for (int i = 0; i < 500; i++)
                        {
                            GlobalCertificateNumbers.Add(i);
                        }
                    }
                    else  //There are already certificate numbers in the DB, fetch them and then build a list
                    {
                        //First get the ID of the last entry in the CertificateNumber table
                        string GetGreatestIDCommandString = "SELECT MAX(CertificateNumberID)  FROM CertificateNumber";
                        using (SQLiteCommand GetGreatestIDCommand = new SQLiteCommand(GetGreatestIDCommandString, conn))
                        {
                            maxID = Convert.ToInt32(GetGreatestIDCommand.ExecuteScalar());
                        }

                        //Second, use maxID to find the latest entry into the table from which we can find the current prefix
                        string GetGreatestPrefixCommandString = "SELECT Prefix FROM CertificateNumber WHERE CertificateNumberID = " + maxID;
                        using (SQLiteCommand GetGreatestPrefixCommand = new SQLiteCommand(GetGreatestPrefixCommandString, conn))
                        {
                            using (SQLiteDataReader getPrefixRdr = GetGreatestPrefixCommand.ExecuteReader())
                            {
                                if (getPrefixRdr.Read())
                                {
                                    GlobalCurrentCertificatePrefix = getPrefixRdr["Prefix"].ToString();
                                }
                            }
                        }

                        List<int> UsedNumbers = new List<int>();
                        string GetUsedNumbersCommandString = string.Format("SELECT Number FROM CertificateNumber WHERE Prefix = '{0}'", GlobalCurrentCertificatePrefix);
                        using (SQLiteCommand GetUsedNumbersCommand = new SQLiteCommand(GetUsedNumbersCommandString, conn))
                        {
                            using (SQLiteDataReader getUsedNumbersRdr = GetUsedNumbersCommand.ExecuteReader())
                            {
                                int outUsedNum;
                                while (getUsedNumbersRdr.Read())
                                {
                                    if (Int32.TryParse(getUsedNumbersRdr["Number"].ToString(), out outUsedNum))
                                    {
                                        UsedNumbers.Add(outUsedNum);
                                    }
                                }
                            }
                        }

                        for (int i = 0; i < 500; i++)
                        {
                            GlobalCertificateNumbers.Add(i);
                        }
                        foreach (int i in UsedNumbers)
                        {
                            GlobalCertificateNumbers.Remove(i);
                        }

                    }

                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("There was a problem loading certificate numbers from the database.  \nError Message", ex.Message));
            }
        }
        public static string GenerateStockCertificateNumber()
        {
            string certificateNumber = "";
            if(GlobalCertificateNumbers.Count == 0) //Time to reinitialize the list of numbers and go to the next prefix
            {
                for(int i = 0; i < 500; i++)
                {
                    GlobalCertificateNumbers.Add(i);
                }
                if (GlobalCurrentCertificatePrefix == "Z")
                {
                    GlobalCurrentCertificatePrefix = "A";
                }
                else
                {
                    GlobalCurrentCertificatePrefix = ((char)(Convert.ToUInt16(GlobalCurrentCertificatePrefix[0]) + 1)).ToString();
                }
            }

            Random ran = new Random(DateTime.Now.Millisecond*seedMultiplier);
            seedMultiplier = seedMultiplier + 2;
            int indexOfStockNumber = ran.Next(0, GlobalCertificateNumbers.Count-1);
            int stockNumber = Globals.GlobalCertificateNumbers[indexOfStockNumber];
            Globals.GlobalCertificateNumbers.RemoveAt(indexOfStockNumber);
            string formattedStockNumber;
            if(stockNumber < 10)
            {
                formattedStockNumber = "00" + stockNumber;
            }
            else if(stockNumber < 100)
            {
                formattedStockNumber = "0" + stockNumber;
            }
            else
            {
                formattedStockNumber = stockNumber.ToString();
            }
            certificateNumber = string.Format("{0} {1}-{2}", GlobalCurrentCertificatePrefix, formattedStockNumber, stockNumber + 500);

            return certificateNumber;
        }


    }
}
