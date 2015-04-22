using FIFLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuturesInFaith1._4
{
    public partial class YouthReportForm : Form
    {
        string sortParameter;
        string YouthName;
        DateTime StartDate;
        DateTime EndDate;
        public YouthReportForm(string param, DateTime startDate, DateTime endDate, string youthName)
        {
            StartDate = startDate;
            EndDate = endDate;
            sortParameter = param;
            YouthName = youthName;
            InitializeComponent();
        }

        private void YouthReportForm_Load(object sender, EventArgs e)
        {
            List<YouthReportItem> youthReportItems = new List<YouthReportItem>();

            if (sortParameter == "YouthOnly" || sortParameter == "Everything")
            {
                var youthInvestments = from Y in Globals.GlobalYouth
                                       join ivt in (Globals.GlobalInvestments.Where(i => i.Date >= StartDate && i.Date <= EndDate))
                                       on Y.YouthID equals ivt.YouthID into g
                                       select new { YouthName = Y.FullName, Investments = g };


                foreach (var yI in youthInvestments)
                {
                    int subTotal = yI.Investments.Sum(i => i.Amount);
                    if (subTotal > 0)
                    {
                        youthReportItems.Add(new YouthReportItem(
                                youthName: yI.YouthName,
                                totalReceived: subTotal
                            ));
                        foreach (Investment2 i in yI.Investments)
                        {
                            youthReportItems.Add(new YouthReportItem(
                                    investmentDate: i.Date,
                                    investmentAmount: i.Amount.ToString(),
                                    investorName: Globals.GlobalInvestors.Where(inv => inv.InvestorID == i.InvestorID).Single().LabelName
                                ));
                        }
                    }
                }

                if(sortParameter == "Everything") //include investments to the general fund
                {
                    var generalFundInvestments = Globals.GlobalInvestments.Where(i => i.CreditTo == "general fund").Select(i => new { i.Date, i.Amount, i.InvestorID });

                    youthReportItems.Add(new YouthReportItem(
                            youthName: "General Fund",
                            totalReceived: generalFundInvestments.ToList().Sum(i=>i.Amount)
                        ));
                    foreach(var gFI in generalFundInvestments)
                    {
                        youthReportItems.Add(new YouthReportItem(
                                investmentDate: gFI.Date,
                                investmentAmount: gFI.Amount.ToString(),
                                investorName: Globals.GlobalInvestors.Where(i=>i.InvestorID == gFI.InvestorID).Single().LabelName
                            ));
                    }
                }
            }

            else if (sortParameter == "GeneralFundOnly")
            {
                var generalFundInvestments = Globals.GlobalInvestments.Where(i => i.CreditTo == "general fund").Select(i => new { i.Date, i.Amount, i.InvestorID });

                youthReportItems.Add(new YouthReportItem(
                        youthName: "General Fund",
                        totalReceived: generalFundInvestments.ToList().Sum(i => i.Amount)
                    ));
                foreach (var gFI in generalFundInvestments)
                {
                    youthReportItems.Add(new YouthReportItem(
                            investmentDate: gFI.Date,
                            investmentAmount: gFI.Amount.ToString(),
                            investorName: Globals.GlobalInvestors.Where(i => i.InvestorID == gFI.InvestorID).Single().LabelName
                        ));
                }
            }
            else //Invidvidual youth
            {
                int youthID = Globals.GlobalYouth.Where(y=>y.FullName == YouthName).Single().YouthID;
                int subTotal = Globals.GlobalInvestments.Where(i => i.YouthID == youthID && i.Date >= StartDate && i.Date <= EndDate).Sum(i => i.Amount);
                var individualYouthInvestments = Globals.GlobalInvestments.Where(i => i.YouthID == youthID && i.Date >= StartDate && i.Date <= EndDate);
                youthReportItems.Add(new YouthReportItem(
                        youthName: YouthName,
                        totalReceived: subTotal
                    ));
                foreach(Investment2 iYI in individualYouthInvestments)
                {
                    youthReportItems.Add(new YouthReportItem(
                            investmentAmount: iYI.Amount.ToString(),
                            investmentDate: iYI.Date,
                            investorName: Globals.GlobalInvestors.Where(inv => inv.InvestorID == iYI.InvestorID).Single().LabelName
                        ));
                }
            }

            YouthReportViewer.LocalReport.DataSources.Clear(); //clear report
            Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("YouthDS", youthReportItems); // set the datasource
            YouthReportViewer.LocalReport.DataSources.Add(dataset);
            dataset.Value = youthReportItems;
            YouthReportViewer.LocalReport.Refresh();
            this.YouthReportViewer.RefreshReport();
        }
    }
}
