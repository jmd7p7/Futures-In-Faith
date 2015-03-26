using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFLibrary
{
    public class YouthReportItem
    {
        public string YouthName { get; set; }
        public int? TotalReceived { get; set; }
        
        public string InvestmentDate { get; set; }
        public string InvestmentAmount { get; set; }
        public string InvestorName { get; set; }
        public YouthReportItem()
        {
            this.YouthName = "";
            this.TotalReceived = 0;
            this.InvestmentDate = default(DateTime).ToString();
            this.InvestmentAmount = "";
            this.InvestorName = "";
        }

        public YouthReportItem(string youthName, int totalReceived)
        {
            this.YouthName = youthName;
            this.TotalReceived = totalReceived;
            this.InvestmentDate = null;
            this.InvestmentAmount = null;
            this.InvestorName = null;
        }

        public YouthReportItem(DateTime investmentDate, string investmentAmount, string investorName)
        {
            this.YouthName = null;
            this.TotalReceived = null;
            this.InvestmentDate = investmentDate.ToShortDateString();
            this.InvestmentAmount = investmentAmount;
            this.InvestorName = investorName;
        }

    }
}
