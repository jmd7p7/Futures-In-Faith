using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFLibrary
{
    public class Investment
    {
        public int InvestmentID { get; set; }
        public int InvestorID { get; set; }
        public DateTime Date { get; set; }
        public string CertificateNumber { get; set; }
        public int CreditTo { get; set; }
        public string CreditAs { get; set; }
        public int YouthID { get; set; }
        public string YouthName { get; set; }
        public int PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; }
        public string CheckNumber { get; set; }
        public bool Reinvest { get; set; }
        public int Amount { get; set; }

        //parameterless constructor
        public Investment()
        {
            this.InvestmentID = -1;
            this.InvestorID = -1;
            this.Date = default(DateTime);
            this.CertificateNumber = "";
            this.CreditTo = -1;
            this.CreditAs = "";
            this.YouthID = -1;
            this.YouthName = "";
            this.PaymentTypeID = -1;
            this.PaymentTypeName = "";
            this.CheckNumber = "";
            this.Reinvest = false;
            this.Amount = -1;
        }

        /// <summary>
        /// Use this Investment constructor when creating a new investment (NOT when loading investments from the database)
        /// Uses the Globals variable 'ID' to set the ID value to an arbitrarily high number.
        /// ***************eventually must implement GenerateCertificateNumber method for this to work correctly**************
        /// </summary>
        /// <param name="investorID"></param>
        /// <param name="date"></param>
        /// <param name="creditTo"></param>
        /// <param name="youthID"></param>
        /// <param name="paymentTypeID"></param>
        /// <param name="checkNumber"></param>
        /// <param name="reinvest"></param>
        /// <param name="amount"></param>
        public Investment(string investorID, string date, string creditTo, string creditAs, 
            string youthID, string youthName, string paymentTypeID, string paymentTypeName, string checkNumber, string reinvest, string amount)
        {
            int _investorID, _youthID, _paymentTypeID, _creditTo, _amount;
            try
            {
                if (Int32.TryParse(investorID, out _investorID) && (Int32.TryParse(creditTo, out _creditTo)) 
                    && (Int32.TryParse(youthID, out _youthID)) && (Int32.TryParse(paymentTypeID, out _paymentTypeID)) 
                    && (Int32.TryParse(amount, out _amount)))
                {
                    this.InvestmentID = Globals.ID;
                    Globals.ID--;
                    this.InvestorID = _investorID;
                    this.Date = Convert.ToDateTime(date);
                    this.CreditTo = _creditTo; //Foreign key for the credit table 
                    this.CreditAs = creditAs; //Name of the credit type, "cash", "check", or ""
                    this.CertificateNumber = GenerateCertificateNumber();
                    this.YouthID = _youthID;
                    this.YouthName = youthName;
                    this.PaymentTypeID = _paymentTypeID;
                    this.PaymentTypeName = paymentTypeName;
                    this.CheckNumber = checkNumber;
                    if (reinvest == "0")
                    {
                        this.Reinvest = false;
                    }
                    else if (reinvest == "1")
                        this.Reinvest = true;
                    else
                        throw new Exception("Invalid data item for Reinvest.  Must be '0' or '1.'");
                    this.Amount = _amount;
                }
                else
                    throw new Exception("Could not parse string to integer value when attempted to create a new investment.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("There was a problem when attempted to create a new investment.  \nError message: {0}", ex.Message));
            }
        }

        private string GenerateCertificateNumber()
        {
            return "A 000-000";
        }


        /// <summary>
        /// Use this Investment constructor when loading investments from the DB
        /// </summary>
        /// <param name="investmentID"></param>
        /// <param name="investorID"></param>
        /// <param name="date"></param>
        /// <param name="creditTo"></param>
        /// <param name="youthID"></param>
        /// <param name="paymentTypeID"></param>
        /// <param name="checkNumber"></param>
        /// <param name="reinvest"></param>
        /// <param name="amount"></param>
        public Investment(string investmentID, string investorID, string date, string creditTo, string creditAs,
            string youthID, string youthName, string paymentTypeID, string paymentTypeName, string certificateNum, 
            string checkNumber, string reinvest, string amount)
        {
            int _investmentID, _investorID, _youthID, _paymentTypeID, _creditTo, _amount;
            try
            {
                if ((Int32.TryParse(investmentID, out _investmentID)) && Int32.TryParse(investorID, out _investorID) && (Int32.TryParse(creditTo, out _creditTo)) && (Int32.TryParse(youthID, out _youthID)) && (Int32.TryParse(paymentTypeID, out _paymentTypeID)) && Int32.TryParse(amount, out _amount))
                {
                    this.InvestmentID = _investmentID;
                    this.InvestorID = _investorID;
                    this.Date = Convert.ToDateTime(date);
                    this.CertificateNumber = certificateNum;
                    this.CreditTo = _creditTo;
                    this.CreditAs = creditAs;
                    this.YouthID = _youthID;
                    this.YouthName = youthName;
                    this.PaymentTypeID = _paymentTypeID;
                    this.PaymentTypeName = paymentTypeName;
                    this.CheckNumber = checkNumber;
                    if (reinvest == "0" || reinvest == "False")
                    {
                        this.Reinvest = false;
                    }
                    else if (reinvest == "1" || reinvest == "True")
                        this.Reinvest = true;
                    else
                        throw new Exception("Invalid data item for Reinvest.  Must be '0' or '1.'");
                    this.Amount = _amount;
                }
                else
                    throw new Exception("Could not parse string to integer value when attempting to create a new investment.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("There was a problem when attempting to create a new investment.  \nError message: {0}", ex.Message));
            }
        }
    }


}
