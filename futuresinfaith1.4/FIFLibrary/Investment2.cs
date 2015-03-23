using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFLibrary
{
    public class Investment2
    {
        public int InvestmentID {get; set;}
        public int InvestorID {get; set;}
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string CertificateNumber { get; set; }
        public string CreditTo { get; set; }
        public int YouthID { get; set; }
        public string PaymentType { get; set; }
        public string CheckNumber { get; set; }
        public bool Reinvst { get; set; }

        public Investment2()
        {
            this.InvestmentID = -1;
            this.InvestorID = -1;
            this.Date = DateTime.Today;
            this.Amount = 0;
            this.CertificateNumber = "";
            this.CreditTo = "";
            this.YouthID = -1;
            this.PaymentType = "";
            this.CheckNumber = "";
            this.Reinvst = false;
        }

        public Investment2 (int _investmentID, int _investorID, string _date, int _amount, 
            string _certificateNumber, string _creditTo, int _youthID, string _paymentType, string _checkNumber, string _reinvest)
        {
            DateTime outDate;
            
            this.InvestmentID = _investmentID;
            this.InvestorID = _investorID;
            if (DateTime.TryParse(_date, out outDate))
            {
                this.Date = outDate;
            }
            else
            {
                this.Date = default(DateTime);
            }
            this.Amount = _amount;
            this.CertificateNumber = _certificateNumber;
            this.CreditTo = _creditTo;
            this.YouthID = _youthID;
            this.PaymentType = _paymentType;
            this.CheckNumber = _checkNumber;
            if (_reinvest == "0")
            {
                this.Reinvst = false;
            }
            else
            {
                this.Reinvst = true;
            }
        }

        //This contstructor is used when creating a new investment.  Note that there is no need to pass an investmentID 
        //in or and certificate number in.
        public Investment2(int _investorID, string _date, int _amount, string _creditTo, 
                           int _youthID, string _paymentType, string _checkNumber, string _reinvest)
        {
            DateTime outDate;

            this.InvestmentID = -1;
            this.InvestorID = _investorID;
            if (DateTime.TryParse(_date, out outDate))
            {
                this.Date = outDate;
            }
            else
            {
                this.Date = default(DateTime);
            }
            this.Amount = _amount;
            this.CertificateNumber = Globals.GenerateStockCertificateNumber();
            this.CreditTo = _creditTo;
            this.YouthID = _youthID;
            this.PaymentType = _paymentType;
            this.CheckNumber = _checkNumber;
            if (_reinvest == "0")
            {
                this.Reinvst = false;
            }
            else
            {
                this.Reinvst = true;
            }
        }


    }
}
