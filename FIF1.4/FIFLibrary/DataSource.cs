//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SQLite;
//using System.Windows.Forms;
//using System.Data;

//namespace FIFLibrary
//{
//    public class DataSource
//    {
//        string conStr;

//        public DataSource(string connectionString)
//        {
//            conStr = connectionString;
//        }

//        public List<KeyValuePair<int, string>> getInvestorsByIdAndName()
//        {
//            List<KeyValuePair<int, string>> investors = new List<KeyValuePair<int, string>>();
//            try
//            {
//                using (SQLiteConnection conn = new SQLiteConnection(conStr))
//                {
//                    string getInvestorsCmdString = string.Format("SELECT InvestorID, LabelName FROM Investor");
//                    conn.Open();
//                    SQLiteCommand cmd = new SQLiteCommand(getInvestorsCmdString, conn);
//                    SQLiteDataReader rdr = cmd.ExecuteReader();
//                    string ID;
//                    int outID;
//                    string name;
//                    while (rdr.Read())
//                    {
//                        ID = rdr["InvestorID"].ToString();
//                        name = rdr["LabelName"].ToString();
//                        if (Int32.TryParse(ID, out outID))
//                        {
//                            investors.Add(new KeyValuePair<int, string>(outID, name));
//                        }
//                    }
//                }

//                return investors;
//            }
//            catch(Exception ex)
//            {
//                MessageBox.Show(string.Format("Unable to load investors from the database.\nError Message: {0}", ex.Message));
//                return investors;
//            }
//        }

//        public List<KeyValuePair<int, string>> getYouthByIDAndName()
//        {
//            List<KeyValuePair<int, string>> youth = new List<KeyValuePair<int, string>>();
//            try
//            {
//                using(SQLiteConnection conn = new SQLiteConnection(conStr))
//                {
//                    conn.Open();
//                    string getYouthCmdString = "SELECT YouthID, FullName FROM Youth";
//                    SQLiteCommand getYouthCmd = new SQLiteCommand(getYouthCmdString, conn);
//                    SQLiteDataReader rdr = getYouthCmd.ExecuteReader();
//                    string ID;
//                    int outID;
//                    string name;
//                    while(rdr.Read())
//                    {
//                        ID = rdr["YouthID"].ToString();
//                        name = rdr["FullName"].ToString();
//                        if(Int32.TryParse(ID, out outID))
//                        {
//                            youth.Add(new KeyValuePair<int, string>(outID, name));
//                        }
//                    }
//                }
//                return youth;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(string.Format("Unable to load youth from the database.\nError Message: {0}", ex.Message));
//                return youth;
//            }
//        }

//        public Investor getInvestorById(int ID)
//        {
//            Investor inv;
//            try
//            {
//                using (SQLiteConnection conn = new SQLiteConnection(conStr))
//                {
//                    string getInvestorCmdString = "SELECT InvestorID, FirstName, LastName, Address, City, State, Zip, Email, Phone, Deceased, JoinDate, LabelName, Notes, LastInvestYear FROM Investor WHERE InvestorID = " + ID;
//                    conn.Open();
//                    SQLiteCommand cmd = new SQLiteCommand(getInvestorCmdString, conn);
//                    SQLiteDataReader rdr = cmd.ExecuteReader();
           
//                    rdr.Read();
//                    inv = new Investor(
//                        rdr["InvestorID"].ToString(),
//                        rdr["FirstName"].ToString(),
//                        rdr["LastName"].ToString(),
//                        rdr["Address"].ToString(),
//                        rdr["City"].ToString(),
//                        rdr["State"].ToString(),
//                        rdr["Zip"].ToString(),
//                        rdr["Phone"].ToString(),
//                        rdr["Email"].ToString(),
//                        rdr["Deceased"].ToString(),
//                        rdr["JoinDate"].ToString(),
//                        rdr["Notes"].ToString(),
//                        rdr["LastInvestYear"].ToString(),
//                        rdr["LabelName"].ToString()
//                    );

//                    string getInvestmentsByInvestorIDCmdString = @"Select I.InvestmentID, I.Date, I.CertificateNumber, I.CreditTo, I.YouthID, I.PaymentTypeID, I.CheckNumber, I.Reinvest, I.Amount, C.CreditType, P.PaymentType, Y.FullName 
//                                                                                 FROM ((((Investment AS I JOIN Investor AS Inv ON I.InvestorID = Inv.InvestorID)
//                                                                                        JOIN Credit as C ON I.CreditTo = C.CreditID)
//                                                                                        JOIN Youth as Y on I.YouthID = Y.YouthID)
//                                                                                        JOIN PaymentType AS P ON I.PaymentTypeID = P.PaymentTypeID)
//                                                                                 WHERE Inv.InvestorID = " + ID;
//                    SQLiteCommand cmdGetInvestments = new SQLiteCommand(getInvestmentsByInvestorIDCmdString, conn);
//                    SQLiteDataReader rdrGetInvestments = cmdGetInvestments.ExecuteReader();
//                    while (rdrGetInvestments.Read())
//                    {
//                        inv.addInvestment(new Investment(
//                                investmentID: rdrGetInvestments["InvestmentID"].ToString(),
//                                investorID: ID.ToString(),
//                                date: rdrGetInvestments["Date"].ToString(),
//                                creditTo: rdrGetInvestments["CreditTo"].ToString(),
//                                creditAs: rdrGetInvestments["CreditType"].ToString(),
//                                youthID: rdrGetInvestments["YouthID"].ToString(),
//                                youthName: rdrGetInvestments["FullName"].ToString(),
//                                paymentTypeID: rdrGetInvestments["PaymentTypeID"].ToString(),
//                                paymentTypeName: rdrGetInvestments["PaymentType"].ToString(),
//                                certificateNum: rdrGetInvestments["CertificateNumber"].ToString(),
//                                checkNumber: rdrGetInvestments["CheckNumber"].ToString(),
//                                reinvest: rdrGetInvestments["Reinvest"].ToString(),
//                                amount: rdrGetInvestments["Amount"].ToString()                          
//                            ));
//                    }
//                    return inv;
//                }
//            }         
//            catch (Exception ex)
//            {
//                MessageBox.Show(string.Format("Unable to load investors from the database.\nError Message: {0}", ex.Message));
//                return null;
//            }
//        }



//        public bool saveAndCloseInvestor(Investor i, List<Investment> investments)
//        {
//            bool success = false;
//            try
//            {
//                using (SQLiteConnection conn = new SQLiteConnection(conStr))
//                {
//                    conn.Open();
//                    int _deceased;
//                    if (i.Deceased == false)
//                    {
//                        _deceased = 0;
//                    }
//                    else
//                    {
//                        _deceased = 1;
//                    }
//                    string updateInvestorCmdString = String.Format(@"UPDATE Investor
//                                         SET InvestorID = {0},
//                                          FirstName = '{1}',
//                                          LastName = '{2}',
//                                          Address = '{3}',
//                                          City = '{4}',
//                                          State= '{5}',
//                                          Zip = '{6}',
//                                          Phone = '{7}',
//                                          Email = '{8}',
//                                          JoinDate = '{9}',
//                                          Deceased = {10},
//                                          LastInvestYear = '{11}',
//                                          Notes = '{12}',
//                                          LabelName = '{13}'
//                                          WHERE InvestorID = {0}", i.getID(), i.FirstName, i.LastName, i.Address, i.City,
//                                                 i.State, i.Zip, i.Phone, i.Email, i.JoinDate.ToShortDateString(), _deceased, i.LastInvestYear, i.Notes, i.LabelName);
//                    SQLiteCommand updateInvestorCmd = new SQLiteCommand(updateInvestorCmdString, conn);
//                    updateInvestorCmd.ExecuteNonQuery();

//                    foreach (Investment inv in investments)
//                    {
//                        int _reinvest;
//                        if(inv.Reinvest == false)
//                        {
//                            _reinvest = 0;
//                        }
//                        else
//                        {
//                            _reinvest = 1;
//                        }
//                        string updateInvestmentCmdString = string.Format(@"UPDATE Investment
//                                    SET InvestmentID = {0},
//                                        InvestorID = {1},
//                                        Date = '{2}',
//                                        CertificateNumber = '{3}',
//                                        CreditTo = {4},
//                                        YouthID = {5},
//                                        PaymentTypeID = {6},
//                                        CheckNumber = '{7}',
//                                        Reinvest = {8},
//                                        Amount = {9}
//                                    WHERE InvestmentID = {0}", inv.InvestmentID, inv.InvestorID, inv.Date.ToShortDateString(),
//                                                             inv.CertificateNumber, inv.CreditTo, inv.YouthID, inv.PaymentTypeID,
//                                                             inv.CheckNumber, _reinvest, inv.Amount);
//                        SQLiteCommand updateInvestmentCmd = new SQLiteCommand(updateInvestmentCmdString, conn);
//                        updateInvestmentCmd.ExecuteNonQuery();
//                    }
//                    return success = true;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(string.Format("Unable to save changes to investor.\nError Message: {0}", ex.Message));
//                return success;
//            }
//        }


//        //This function validates that the investment information in a datagridviewrow
//        //This is probably going to be deleted
//        public string validateInvestmentRow(System.Windows.Forms.DataGridViewRow r)
//        {
//            string result = "false";

//            try
//            {
//                DateTime Temp;
//                if (!DateTime.TryParse(r.Cells["Date"].ToString(), out Temp))
//                {
//                    throw new Exception("Invalid date format.  The proper format is: mm/dd/yyyy");
//                }
//                if (r.Cells["CreditAs"].ToString() != "General Fund" || r.Cells["CreditAs"].ToString() != "Youth" ||
//                    r.Cells["CreditAs"].ToString() != "")
//                {
//                    throw new Exception("The value for credit as must be 'General Fund', 'Youth', or be left blank");
//                }
//                using(SQLiteConnection conn = new SQLiteConnection(conStr))
//                {
//                    bool found = false;
//                    string getYouthCmdString = "SELECT FullName FROM Youth";
//                    conn.Open();
//                    SQLiteCommand getYouthCmd = new SQLiteCommand(getYouthCmdString, conn);
//                    SQLiteDataReader rdr = getYouthCmd.ExecuteReader();
//                    while (rdr.Read() && found == false)
//                    {
//                        if(rdr["FullName"].ToString()== r.Cells["YouthName"].ToString())
//                        {
//                            found = true;
//                        }
//                    }
//                    if (found == false)
//                    {
//                        throw new Exception(String.Format(@"Youth '{0}' not found in the database.\n
//                                                          Make sure you have entered the name correctly or\n
//                                                          enter the youth into the Database before attempting to enter investments.", r.Cells["YouthName"].ToString()));
//                    }
//                    if(r.Cells["PaymentTypeName"].ToString() != "Cash" || r.Cells["PaymentTypeName"].ToString() != "Check" || r.Cells["PaymentTypeName"].ToString() != "")
//                    {
//                        throw new Exception("Payment Type must be 'Cash', 'Check', or left blank");
//                    }
//                }

//            }
//            catch (Exception ex)
//            {
//                System.Windows.Forms.MessageBox.Show(ex.Message);
//            }
//            return result;
//        }

//        public AutoCompleteStringCollection YouthAutoComplete()
//        {
//            try
//            {
//                AutoCompleteStringCollection allYouth = new AutoCompleteStringCollection();
//                using(SQLiteConnection conn = new SQLiteConnection(conStr))
//                {
//                    string getYouthCmdString = "SELECT FullName FROM Youth";
//                    conn.Open();
//                    SQLiteCommand getYouthCmd = new SQLiteCommand(getYouthCmdString, conn);
//                    SQLiteDataReader rdr = getYouthCmd.ExecuteReader();

//                    while (rdr.Read())
//                    {
//                        allYouth.Add(rdr["FullName"].ToString());
//                    }
//                }
//                return allYouth;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(string.Format("There was a problem loading the youth into the AutoComplete filed of the datagridview.  \nError Message: {0}", ex.Message));
//                return null;
//            }

//        }


//        public bool saveAndCloseNewInvestor(Investor newInvestor, List<Investment> newInvestments)
//        {
//            bool success = false;
//            try
//            {
//                using (SQLiteConnection conn = new SQLiteConnection(conStr))
//                {
//                    int _deceased = 0;
//                    if (newInvestor.Deceased == true)
//                    {
//                        _deceased = 1;
//                    }
//                    string insertNewInvestorCommandString = string.Format(@"INSERT INTO Investor (FirstName, LastName, Address, City, State, Zip, Email, Phone, Deceased, JoinDate, LabelName, Notes, LastInvestYear)
//                                                                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
//                                                                     newInvestor.FirstName, newInvestor.LastName, newInvestor.Address, newInvestor.City, newInvestor.State,
//                                                                     newInvestor.Zip, newInvestor.Email, newInvestor.Phone, _deceased, newInvestor.JoinDate,
//                                                                     newInvestor.LabelName, newInvestor.Notes, DateTime.Now.Year);
//                    SQLiteCommand insertNewInvestorCommand = new SQLiteCommand(insertNewInvestorCommandString, conn);
//                    conn.Open();
//                    insertNewInvestorCommand.ExecuteNonQuery();
//                }

//                using (SQLiteConnection conn = new SQLiteConnection(conStr))
//                {
//                    conn.Open();
//                    foreach (Investment inv in newInvestments)
//                    {
//                        int _reinvest;
//                        string _youthName;
//                        string _checkNum;
//                        if (inv.Reinvest == false)
//                        {
//                            _reinvest = 0;
//                        }
//                        else
//                        {
//                            _reinvest = 1;
//                        }
//                        if(inv.YouthName == null || inv.YouthName == "")
//                        {
//                            _youthName = "N/A";
//                        }
//                        else
//                        {
//                            _youthName = inv.YouthName;
//                        }

//                        if(inv.CheckNumber == null || inv.CheckNumber == "")
//                        {
//                            _checkNum = "";
//                        }
//                        else
//                        {
//                            _checkNum = inv.CheckNumber;
//                        }
//                        string insertNewInvestmentCommandString =
//                            string.Format(@"INSERT INTO Investment (InvestorID, Date, CertificateNumber, CreditTo, YouthID, PaymentTypeID, CheckNumber, Reinvest, Amount) 
//                                            VALUES((SELECT InvestorID FROM Investor WHERE LabelName = '{0}'), '{1}', '{2}', 
//                                            (SELECT CreditID FROM Credit WHERE CreditType ='{3}'), (SELECT YouthID from Youth WHERE FullName = '{4}'), 
//                                            (SELECT PaymentTypeID FROM PaymentType WHERE PaymentType = '{5}'), '{6}', {7}, {8});", 
//                                            newInvestor.LabelName, inv.Date.ToShortDateString(), inv.CertificateNumber,
//                                            inv.CreditAs, _youthName, inv.PaymentTypeName, _checkNum, _reinvest, inv.Amount);
                                                    
//                        SQLiteCommand insertNewInvestmentCommand = new SQLiteCommand(insertNewInvestmentCommandString, conn);
//                        insertNewInvestmentCommand.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch(Exception ex)
//            {
//                MessageBox.Show(String.Format(@"There was a problem when attempting to insert the new investor (and investments).  
//                                                \nError message: {0}", ex.Message));
//                return success;
//            }
//            return success = true;
//        }

//        public bool CheckIfYouthExists(string fullName)
//        {
//            bool exists = false;
//            try
//            {
//                using (SQLiteConnection conn = new SQLiteConnection(conStr))
//                {
//                    int count;
//                    string CheckIfExistsCommandString = string.Format(@"SELECT COUNT(YouthID) FROM Youth Where FullName = '{0}'", fullName);
//                    SQLiteCommand CheckIfExistsCommand = new SQLiteCommand(CheckIfExistsCommandString, conn);
//                    conn.Open();
//                    SQLiteDataReader rdr = CheckIfExistsCommand.ExecuteReader();
//                    while (rdr.Read())
//                    {
//                        if (Int32.TryParse(rdr["COUNT(YouthID)"].ToString(), out count))
//                        {
//                            if (count > 0)
//                            {
//                                if(rdr != null)
//                                {
//                                    rdr.Close();
//                                }
//                                return exists = true;
//                            }
//                        }
//                        else
//                        {
//                            if (rdr != null)
//                            {
//                                rdr.Close();
//                            }
//                            return exists;
//                        }
//                    }
//                }
//            }
//            catch(Exception ex)
//            {
//                MessageBox.Show(String.Format("Could not verify that youth exists in the database.  \nError Message: {0}", ex.Message));
//                return exists;
//            }
//            return exists;
//        }

//        public bool AddNewYouth(string fName, string lName)
//        {
//            bool success = false;
//            int numRowsInserted;
//            try
//            {
//                using (SQLiteConnection conn = new SQLiteConnection(conStr))
//                {
//                    string AddNewYouthCommandString = string.Format(@"INSERT INTO Youth (FirstName, LastName, FullName, IsActive)
//                                                                  VALUES ('{0}', '{1}', '{2}', {3});",
//                                                                      fName, lName, lName + ", " + fName, 1);
//                    SQLiteCommand AddNewYouthCommand = new SQLiteCommand(AddNewYouthCommandString, conn);
//                    conn.Open();
//                    numRowsInserted = AddNewYouthCommand.ExecuteNonQuery();
//                    if (numRowsInserted == 1)
//                    {
//                        return success = true;
//                    }
//                    else
//                    {
//                        throw new Exception();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(string.Format("There was a problem when trying to add the youth to the database.  \nError Message: {0}", ex.Message));
//                return success;
//            }
//        }

//        //Saturday, 3/14 - this is where I left of
//        //public Youth getSingleYouthByID(int ID)
//        //{
//        //    Youth _youth;
//        //    using(SQLiteConnection conn = new SQLiteConnection(conStr))
//        //    {
//        //        string getSingleYouthCommandString = string.Format(@"SELECT FirstName, LastName, FullName, IsActive FROM Youth WHERE YouthID = {0}", ID);
//        //    }
//        //    return _youth;
//        //}


//        #region  OLD DATA SOURCE CODE


//        //Use 'SaveInvestor' when inserting a NEW investor into the DB
//        public void SaveInvestor(string firstName, string lastName, string address,
//            string city, string state, string zip, string phone, string email,
//            string deceased, string joinDate, string notes)
//        {
//            SQLiteConnection conn = new SQLiteConnection(conStr);
//            string saveInvestorCommandString = string.Format(@"INSERT INTO Investor (FirstName, LastName, Address, City, State, Zip, Email, Phone, Deceased, JoinDate, LabelName, Notes, LastInvestYear)
//                                                                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
//                                                                 firstName, lastName, address, city, state, zip, email, phone, deceased, joinDate, lastName + ", " + firstName, notes, DateTime.Now.Year.ToString());
//            SQLiteCommand saveInvestorCommand = new SQLiteCommand(saveInvestorCommandString, conn);
//            conn.Open();
//            saveInvestorCommand.ExecuteNonQuery();
//            conn.Dispose();
//        }

//        //use 'UpdateInvestor' when updating an existing investor's information
//        //**********Need to update to add the correct LastInvestYear when adding new investments**********
//        //public void UpdateInvestor(int ID, string firstName, string lastName, string address, string city, string state, string zip,
//        //                           string phone, string email, bool deceased, DateTime joinDate, string lastInvestYear, string notes, string labelName)
//        //{
//        //    int _deceased;
//        //    if(deceased == false)
//        //    {
//        //        _deceased = 0;
//        //    }
//        //    else
//        //        _deceased = 1;
//        //    SQLiteConnection conn = new SQLiteConnection(conStr);
//        //    string updateInvestorCommandString = string.Format(@"UPDATE Investor set FirstName = '{1}', LastName = '{2}', Address = '{3}', City = '{4}', State = '{5}', Zip = '{6}', Email = '{7}', Phone = '{8}', JoinDate = '{9}', Deceased = '{10}', LabelName = '{11}', Notes = '{12}', LastInvestYear = '{13}' WHERE InvestorID = {0};",
//        //        ID, firstName, lastName, address, city, state, zip, email, phone, joinDate.ToShortDateString(), _deceased, labelName, notes, lastInvestYear);
//        //    SQLiteCommand updateInvestorCommand = new SQLiteCommand(updateInvestorCommandString, conn);
//        //    conn.Open();
//        //    updateInvestorCommand.ExecuteNonQuery();
//        //    conn.Dispose();
//        //}

//        //public void AddInvestment(string investorID, string date, string creditTo, string creditAs,
//        //    string youthID, string youthName, string paymentTypeID, string paymentTypeName, string checkNumber, string reinvest, string amount)
//        //{
//        //    Investments.Add(new Investment(investorID, date, creditTo, creditAs, youthID, youthName, 
//        //                    paymentTypeID, paymentTypeName, checkNumber, reinvest, amount));
//        //}

//        public List<Investment> GetInvestmentsForInvestor(int investorID)
//        {
//            try
//            {
//                List<Investment> _investments = new List<Investment>();
//                SQLiteConnection conn = new SQLiteConnection(conStr);
//                string getInvestmentsCommandString = (string.Format(@"SELECT I.InvestmentID, I.Date, I.CertificateNumber, I.CreditTo, C.CreditType, I.YouthID, Y.FullName, I.PaymentTypeID, P.PaymentType, I.CheckNumber, I.Reinvest, I.Amount FROM ((((Investment AS I JOIN Credit AS C ON I.CreditTo = C.CreditID) JOIN Youth AS Y ON I.YouthID = Y.YouthID) JOIN PaymentType as P on I.PaymentTypeID = P.PaymentTypeID) JOIN Investor AS Inv ON I.InvestorID = Inv.InvestorID) WHERE Inv.InvestorID = {0}", investorID));
//                SQLiteCommand getInvestorCommand = new SQLiteCommand(getInvestmentsCommandString, conn);
//                conn.Open();
//                SQLiteDataReader readInvestments = getInvestorCommand.ExecuteReader();
//                while (readInvestments.Read())
//                {
//                    _investments.Add(new Investment(
//                            investmentID: readInvestments["InvestmentID"].ToString(),
//                            investorID: investorID.ToString(),
//                            date: readInvestments["Date"].ToString(),
//                            certificateNum: readInvestments["CertificateNumber"].ToString(),
//                            creditTo: readInvestments["CreditTo"].ToString(),
//                            creditAs: readInvestments["CreditType"].ToString(),
//                            youthID: readInvestments["YouthID"].ToString(),
//                            youthName: readInvestments["FullName"].ToString(),
//                            paymentTypeID: readInvestments["PaymentTypeID"].ToString(),
//                            paymentTypeName: readInvestments["PaymentType"].ToString(),
//                            checkNumber: readInvestments["CheckNumber"].ToString(),
//                            reinvest: readInvestments["Reinvest"].ToString(),
//                            amount: readInvestments["Amount"].ToString()
//                        ));
//                }
//                conn.Dispose();
//                return _investments;
//            }
//            catch(Exception ex)
//            {
//                MessageBox.Show(String.Format("Could not load investments for the selected investor. \nError Message: {0}", ex.Message));
//                return null;
//            }
//        }

//        //public List<Investor> getInvestors()
//        //{
//        //    return Investors;
//        //}

//        public void GetInvestmentsByInvestorID(int investorID, DataGridView dgv)
//        {
//            List<Investment> usersInvestments = new List<Investment>();
//            string getInvestmentsCommandString = (string.Format(@"SELECT I.InvestmentID, I.Date, I.CertificateNumber, I.CreditTo, C.CreditType, I.YouthID, Y.FullName, I.PaymentTypeID, P.PaymentType, I.CheckNumber, I.Reinvest, I.Amount FROM ((((Investment AS I JOIN Credit AS C ON I.CreditTo = C.CreditID) JOIN Youth AS Y ON I.YouthID = Y.YouthID) JOIN PaymentType as P on I.PaymentTypeID = P.PaymentTypeID) JOIN Investor AS Inv ON I.InvestorID = Inv.InvestorID) WHERE Inv.InvestorID = {0}", investorID));
//            SQLiteDataAdapter da = new SQLiteDataAdapter(getInvestmentsCommandString, conStr);

//            DataSet ds = new DataSet();
//            da.Fill(ds);
//            dgv.DataSource = ds;
//        }
//    }
//        #endregion
//}
