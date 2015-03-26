using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIFLibrary;

namespace FuturesInFaith1._4
{
    public partial class InvestmentsReportForm : Form
    {
        string sortParameter;
        DateTime StartDate;
        DateTime EndDate;
        public InvestmentsReportForm(string param, DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            sortParameter = param;
            InitializeComponent();
        }

        private void InvestmentsReportForm_Load(object sender, EventArgs e)
        {
            List<InvestmentReportItem> reportItems;
            //First, join the investments and investor tables and build the InvestmentReportItem list for the report
            List<InvestmentReportItem> reportItemsWithoutYouth = (from ivr in Globals.GlobalInvestors
                                                      join ivt in Globals.GlobalInvestments on
                                                      ivr.InvestorID equals ivt.InvestorID
                                                      where ivt.YouthID == -1 && ivt.Date >= StartDate && ivt.Date <= EndDate
                                                      select new InvestmentReportItem(
                                                      
                                                          ivr.LabelName,
                                                          ivr.Email,
                                                          ivr.Address,
                                                          ivr.City,
                                                          ivr.State,
                                                          ivr.Zip,
                                                          ivr.Phone,
                                                          ivt.CreditTo,
                                                          ivt.Date,
                                                          ivt.Amount,
                                                          ivt.Reinvst,
                                                          ivt.CertificateNumber
                                                      )).ToList();

            List<InvestmentReportItem> reportItemsWithYouth = (from ivr in Globals.GlobalInvestors
                                                      join ivt in Globals.GlobalInvestments on
                                                      ivr.InvestorID equals ivt.InvestorID
                                                      join y in Globals.GlobalYouth on 
                                                      ivt.YouthID equals y.YouthID
                                                      where ivt.Date >= StartDate && ivt.Date <= EndDate
                                                      select new InvestmentReportItem(

                                                          ivr.LabelName,
                                                          ivr.Email,
                                                          ivr.Address,
                                                          ivr.City,
                                                          ivr.State,
                                                          ivr.Zip,
                                                          ivr.Phone,
                                                          y.FullName,
                                                          ivt.Date,
                                                          ivt.Amount,
                                                          ivt.Reinvst,
                                                          ivt.CertificateNumber
                                                      )).ToList();

            if(reportItemsWithYouth.Count > 0 && reportItemsWithoutYouth.Count > 0)
            {
                reportItemsWithYouth.AddRange(reportItemsWithoutYouth);
                reportItems = reportItemsWithYouth;
            }
            else if (reportItemsWithYouth.Count == 0 && reportItemsWithoutYouth.Count == 0)
            {
                reportItems = new List<InvestmentReportItem>();
                MessageBox.Show("There are no investments in the database that match your search criteria.");
                this.Close();
                return;
            }
            else if(reportItemsWithoutYouth.Count == 0)
            {
                reportItems = reportItemsWithYouth;
            }
            else
            {
                reportItems = reportItemsWithoutYouth;
            }


            if(sortParameter == "name")
            {
                InvestmentsReportViewer.LocalReport.DataSources.Clear(); //clear report
                Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("InvestmentDS", reportItems); // set the datasource
                InvestmentsReportViewer.LocalReport.DataSources.Add(dataset);
                dataset.Value = reportItems.OrderBy(i=>i.InvestorName);
                InvestmentsReportViewer.LocalReport.Refresh();
                this.InvestmentsReportViewer.RefreshReport();
            }
            else
            {
                InvestmentsReportViewer.LocalReport.DataSources.Clear(); //clear report
                Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("InvestmentDS", reportItems); // set the datasource
                InvestmentsReportViewer.LocalReport.DataSources.Add(dataset);
                dataset.Value = reportItems.OrderBy(i => i.CertificateNumber);
                InvestmentsReportViewer.LocalReport.Refresh();
                this.InvestmentsReportViewer.RefreshReport();
            }
            this.InvestmentsReportViewer.RefreshReport();
        }
    }
}
