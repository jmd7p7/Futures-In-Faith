using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFLibrary
{
    public class InvestmentReportItem
    {
        public string InvestorName { get; set; }
        public string InvestorEmail { get; set; }
        public string InvestorAddress { get; set; }
        public string InvestorPhone { get; set; }
        public string CreditTo { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }
        public string IfWin { get; set; }
        public string CertificateNumber { get; set; }

        public InvestmentReportItem()
        {
            this.InvestorName = "";
            this.InvestorEmail = "";
            this.InvestorAddress = "";
            this.InvestorPhone = "";
            this.CreditTo = "";
            this.Date = "";
            this.Amount = 0;
            this.IfWin = "";
            this.CertificateNumber = "";
        }

        public InvestmentReportItem(string _name, string _email, string _address, string _city, string _state, string _zip, 
            string _phone, string _creditTo, DateTime _date, int _amount, bool _reinvest, string _certificateNum)
        {
            string _ifWin;
            if(_reinvest == true)
            {
                _ifWin = "Reinvest";
            }
            else
            {
                _ifWin = "Check";
            }
            this.InvestorName = _name;
            this.InvestorEmail = _email;
            this.InvestorAddress = string.Format("{0}, {1}, {2} {3}", _address, _city, _state, _zip);
            this.InvestorPhone = _phone;
            this.CreditTo = _creditTo;
            this.Date = _date.ToShortDateString();
            this.Amount = _amount;
            this.IfWin = _ifWin;
            this.CertificateNumber = _certificateNum;
        }
    }
}
