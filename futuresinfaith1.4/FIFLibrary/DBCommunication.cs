using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FIFLibrary
{
    public static class DBCommunication
    {
        //Returns ALL investments currently in the DB
        public static List<Investment2> GetInvestments()
        {
            List<Investment2> AllInvestments = new List<Investment2>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    string getInvestmentsCommandString = "SELECT InvestmentID, InvestorID, Date, CertificateNumber, CreditTo, YouthID, PaymentTypeID, CheckNumber, Reinvest, Amount FROM Investment";
                    using (SQLiteCommand getInvestmentsCommand = new SQLiteCommand(getInvestmentsCommandString, conn))
                    {
                        conn.Open();
                        using (SQLiteDataReader rdr = getInvestmentsCommand.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                string _creditTo;
                                string _paymentType;
                                if (rdr["CreditTo"].ToString() == "1")
                                {
                                    _creditTo = "general fund";
                                }
                                else if (rdr["CreditTo"].ToString() == "2")
                                {
                                    _creditTo = "youth";
                                }
                                else
                                {
                                    _creditTo = "";
                                }

                                if (rdr["PaymentTypeID"].ToString() == "1")
                                {
                                    _paymentType = "cash";
                                }
                                else if (rdr["PaymentTypeID"].ToString() == "2")
                                {
                                    _paymentType = "check";
                                }
                                else
                                {
                                    _paymentType = "";
                                }

                                int _investmentID, _investorID, _youthID, _amount;
                                if (Int32.TryParse(rdr["InvestmentID"].ToString(), out _investmentID) &&
                                   Int32.TryParse(rdr["InvestorID"].ToString(), out _investorID) &&
                                   Int32.TryParse(rdr["YouthID"].ToString(), out _youthID) &&
                                   Int32.TryParse(rdr["Amount"].ToString(), out _amount))
                                {
                                    AllInvestments.Add(new Investment2(
                                            _investmentID: _investmentID,
                                            _investorID: _investorID,
                                            _date: rdr["Date"].ToString(),
                                            _amount: _amount,
                                            _certificateNumber: rdr["CertificateNumber"].ToString(),
                                            _creditTo: _creditTo,
                                            _youthID: _youthID,
                                            _paymentType: _paymentType,
                                            _checkNumber: rdr["CheckNumber"].ToString(),
                                            _reinvest: rdr["Reinvest"].ToString()
                                            ));
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(
                    "Unable to load investments from the Database. \nError Message: {0}", ex.Message));
            }
            return AllInvestments;
        }

        //Returns ALL investors currently in the DB
        public static List<Investor2> GetInvestors()
        {
            List<Investor2> AllInvestors = new List<Investor2>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    string getInvestorsCommandString = "SELECT InvestorID, FirstName, LastName, Address, City, State, Zip, Email, Phone, Deceased, JoinDate, LabelName, Notes, LastInvestYear FROM Investor";
                    using (SQLiteCommand getInvestorsCommand = new SQLiteCommand(getInvestorsCommandString, conn))
                    {
                        conn.Open();
                        using (SQLiteDataReader rdr = getInvestorsCommand.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                AllInvestors.Add(new Investor2(
                                        _investorID: rdr["InvestorID"].ToString(),
                                        _firstName: rdr["FirstName"].ToString(),
                                        _lastName: rdr["LastName"].ToString(),
                                        _address: rdr["Address"].ToString(),
                                        _city: rdr["City"].ToString(),
                                        _state: rdr["State"].ToString(),
                                        _zip: rdr["Zip"].ToString(),
                                        _email: rdr["Email"].ToString(),
                                        _phone: rdr["Phone"].ToString(),
                                        _deceased: rdr["Deceased"].ToString(),
                                        _joinDate: rdr["JoinDate"].ToString(),
                                        _labelName: rdr["LabelName"].ToString(),
                                        _notes: rdr["Notes"].ToString(),
                                        _lastInvestYear: rdr["LastInvestYear"].ToString()
                                    ));
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(
                    "Unable to load investors from the Database. \nError Message: {0}", ex.Message));
            }
            return AllInvestors.OrderBy(i=>i.LabelName).ToList();
        }

        //Save a NEW investor to the DB
        public static bool SaveNewInvestor(string _firstName, string _lastName, string _address, string _city, string _state,
            string _zip, string _email, string _phone, bool _deceased, DateTime _joinDate, string _notes)
        {
            string _labelName = _lastName + ", " + _firstName;
            bool success = false;
            int _intDeceased;
            if(_deceased == false)
            {
                _intDeceased = 0;
            }
            else
            {
                _intDeceased = 1;
            }
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    conn.Open();
                    string InsertInvestorCommandString = String.Format(@"INSERT INTO Investor (FirstName, LastName, Address, City, State, Zip, Email, Phone, Deceased, JoinDate, LabelName, Notes, LastInvestYear) 
                                                                     VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}');",
                                                                         _firstName, _lastName, _address, _city, _state, _zip, _email, _phone, _intDeceased, _joinDate.ToShortDateString(), _labelName, _notes, DateTime.Now.Year.ToString());
                    SQLiteCommand InsertInvestorCommand = new SQLiteCommand(InsertInvestorCommandString, conn);
                    InsertInvestorCommand.ExecuteNonQuery();
                    return success = true;
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Unable to save investor and investments to the database.  \nError message: {0}", ex.Message));
                return success;
            }
        }

        //Update information for an investor already in the DB
        public static bool UpdateInvestor(int _investorID, string _firstName, string _lastName, string _address, string _city, string _state,
            string _zip, string _email, string _phone, bool _deceased, DateTime _joinDate, string _notes, string _labelName, string _lastInvestYear)
        {
            bool success = false;
            int intDeceased;
            if(_deceased == false)
            {
                intDeceased = 0;
            }
            else
            {
                intDeceased = 1;
            }
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    conn.Open();
                    string updateInvestorCommandString = 
                        string.Format(@"UPDATE Investor SET 
                                        FirstName = '{1}',
                                        LastName = '{2}',
                                        Address = '{3}',
                                        City = '{4}',
                                        State = '{5}',
                                        Zip = '{6}',
                                        Email = '{7}',
                                        Phone = '{8}',
                                        Deceased = {9},
                                        JoinDate = '{10}',
                                        LabelName = '{11}',
                                        Notes = '{12}',
                                        LastInvestYear = '{13}'
                                        WHERE InvestorID = {0}", _investorID, _firstName, _lastName, _address, _city, _state, _zip, _email, _phone, intDeceased, _joinDate.ToShortDateString(), _labelName, _notes, _lastInvestYear);
                    SQLiteCommand updateInvestorCommand = new SQLiteCommand(updateInvestorCommandString, conn);
                    updateInvestorCommand.ExecuteNonQuery();
                    return success = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Unable to update investor's personal information and investments to the database.", ex.Message));
                return success;
            }
        }

        public static List<Youth> GetYouth()
        {
            List<Youth> allYouth = new List<Youth>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    string GetYouthCommandString = "SELECT YouthID, FirstName, LastName, FullName, IsActive FROM Youth";
                    using (SQLiteCommand GetYouthCommand = new SQLiteCommand(GetYouthCommandString, conn))
                    {
                        conn.Open();
                        using (SQLiteDataReader rdr = GetYouthCommand.ExecuteReader())
                        {

                            int outYouthID;
                            bool isActive;
                            while (rdr.Read())
                            {
                                if (rdr["IsActive"].ToString() == "0")
                                {
                                    isActive = false;
                                }
                                else
                                {
                                    isActive = true;
                                }
                                if (Int32.TryParse(rdr["YouthID"].ToString(), out outYouthID))
                                {
                                    allYouth.Add(new Youth(
                                            id: outYouthID,
                                            fName: rdr["FirstName"].ToString(),
                                            lName: rdr["LastName"].ToString(),
                                            fullName: rdr["FullName"].ToString(),
                                            active: isActive
                                        ));
                                }
                                else
                                {
                                    throw new Exception("Could not parse YouthID to integer");
                                }
                            }
                        }
                    }
                }
                return allYouth;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Unable to load youth from the database.  \nError Message: {0}", ex.Message));
                return new List<Youth>();
            }
        }
        public static List<string> GetYouthFullNames()
        {
            List<string> youth = new List<string>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    conn.Open();
                    string GetYouthCommandString = "Select FullName from Youth";
                    SQLiteCommand GetYouthCommand = new SQLiteCommand(GetYouthCommandString, conn);
                    SQLiteDataReader rdr = GetYouthCommand.ExecuteReader();
                    while (rdr.Read())
                    {
                        youth.Add(rdr["FullName"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Unable to load youth for the Datagridview youth combobox.  \nError Message: ", ex.Message));
                return new List<string>();
            }
            return youth;
        }
        
        public static bool SaveNewInvestments(List<Investment2> newInvestments)
        {
            bool success = false;

            int paymentTypeID;
            int creditTo;
            int reinvest;
            using(SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
            {
                conn.Open();
                try
                {
                    foreach (Investment2 inv in newInvestments)
                    {
                        if (inv.Reinvst == true)
                        {
                            reinvest = 1;
                        }
                        else
                        {
                            reinvest = 0;
                        }
                        if (inv.CreditTo == null || inv.CreditTo == "N/A")
                        {
                            creditTo = 3;
                        }
                        else if (inv.CreditTo == "general fund")
                        {
                            creditTo = 1;
                        }
                        else
                        {
                            creditTo = 2;
                        }

                        if (inv.PaymentType == null || inv.PaymentType == "N/A")
                        {
                            paymentTypeID = 3;
                        }
                        else if (inv.PaymentType == "cash")
                        {
                            paymentTypeID = 1;
                        }
                        else
                        {
                            paymentTypeID = 2;
                        }
                        String InsertNewInvestmentCommandString =
                            string.Format(@"INSERT INTO Investment(
                                        InvestorID, Date, CertificateNumber, CreditTo, YouthID, PaymentTypeID, 
                                        CheckNumber, Reinvest, Amount)
                                        VALUES ({0}, '{1}', '{2}', {3}, {4}, {5}, '{6}', {7}, {8})",
                                            inv.InvestorID, inv.Date.ToShortDateString(), inv.CertificateNumber, creditTo, inv.YouthID, paymentTypeID,
                                            inv.CheckNumber, reinvest, inv.Amount);
                        SQLiteCommand InsertNewInvestmentCommand = new SQLiteCommand(InsertNewInvestmentCommandString, conn);
                        InsertNewInvestmentCommand.ExecuteNonQuery();
                        Globals.GlobalCertificateNumbersToDelete.Add(inv.CertificateNumber);
                    }
                    return success = true;
                }
                catch(Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(
                        string.Format("Unable to add all new investments. Some new investments may have been added.  Please check the investments for this investor. \nError Message: ", ex.Message));
                    return success;
                }
            }
        }
        public static bool UpdateInvestments(List<Investment2> InvestmentsToUpdate)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    conn.Open();
                    int paymentTypeID;
                    int creditTo;
                    int reinvest;

                    foreach (Investment2 inv in InvestmentsToUpdate)
                    {
                        if (inv.Reinvst == true)
                        {
                            reinvest = 1;
                        }
                        else
                        {
                            reinvest = 0;
                        }
                        if (inv.CreditTo == null || inv.CreditTo == "N/A")
                        {
                            creditTo = 3;
                        }
                        else if (inv.CreditTo == "general fund")
                        {
                            creditTo = 1;
                        }
                        else
                        {
                            creditTo = 2;
                        }

                        if (inv.PaymentType == null || inv.PaymentType == "N/A")
                        {
                            paymentTypeID = 3;
                        }
                        else if (inv.PaymentType == "cash")
                        {
                            paymentTypeID = 1;
                        }
                        else
                        {
                            paymentTypeID = 2;
                        }

                        string UpdateInvestmentCommandString
                            = string.Format(@"UPDATE Investment SET
                                      InvestorID = {0}, Date = '{1}', CertificateNumber = '{2}',
                                      CreditTo = {3}, YouthID = {4}, PaymentTypeID = {5},
                                      CheckNumber = '{6}', Reinvest = {7}, Amount = {8}
                                      WHERE InvestmentID = {9}", inv.InvestorID, inv.Date.ToShortDateString(),
                                           inv.CertificateNumber, creditTo, inv.YouthID, paymentTypeID, inv.CheckNumber,
                                           reinvest, inv.Amount, inv.InvestmentID);
                        SQLiteCommand UpdateInvestmentCommand = new SQLiteCommand(UpdateInvestmentCommandString, conn);
                        UpdateInvestmentCommand.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("There was a problem updating the ivestor's investments (New investments, if any, were successfully added).  \nError message: ", ex.Message));
                return false;
            }
        }

        public static bool SaveCertificateNumber(List<string> certNumbers)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    conn.Open();
                    foreach (string cert in certNumbers)
                    {
                        string _prefix = cert[0].ToString();
                        string _numberStr = cert.Substring(cert.IndexOf("-") + 1, 3);
                        int _number;
                        if (Int32.TryParse(_numberStr, out _number)) { }
                        string insertCertificateNumberCommandString = string.Format("INSERT INTO CertificateNumber (Prefix, Number) VALUES('{0}', {1})", _prefix, _number-500);
                        using (SQLiteCommand insertCertificateCommand = new SQLiteCommand(insertCertificateNumberCommandString, conn))
                        {
                            insertCertificateCommand.ExecuteNonQuery();
                        }
                    }
                    return true;
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Could not save certificate number to the database.  Error message: ", ex.Message));
                return false;
            }
        }

        public static bool AddNewYouth(string fName, string lName)
        {
            bool success = false;
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    string AddNewYouthCommandString = string.Format(@"INSERT INTO Youth (FirstName, LastName, FullName, IsActive)
                                                                  VALUES ('{0}', '{1}', '{2}', {3});",
                                                                      fName, lName, lName + ", " + fName, 1);
                    using (SQLiteCommand AddNewYouthCommand = new SQLiteCommand(AddNewYouthCommandString, conn))
                    {
                        conn.Open();
                        AddNewYouthCommand.ExecuteNonQuery();
                        Globals.rebindYouthOnMainForm = true;
                        return success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("There was a problem when trying to add the youth to the database.  \nError Message: {0}", ex.Message));
                return success;
            }
        }

        public static bool UpdateYouth(Youth youth)
        {
            try
            {
                using(SQLiteConnection conn = new SQLiteConnection(Globals.ConnectionString))
                {
                    int isActive = 1;
                    if(youth.IsActive == false)
                    {
                        isActive = 0;
                    }
                    string UpdateYouthCommandString = 
                        string.Format("UPDATE Youth SET FirstName = '{0}', LastName = '{1}', FullName = '{2}', IsActive = {3} WHERE YouthID = {4}",
                        youth.FirstName, youth.LastName, youth.FullName, isActive, youth.YouthID);
                    using(SQLiteCommand UpdateYouthCommand = new SQLiteCommand(UpdateYouthCommandString, conn))
                    {
                        conn.Open();
                        UpdateYouthCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Unable to update youth in the database.  \nError message: ", ex.Message));
                return false;
            }
        }
    }
}
