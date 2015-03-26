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
    public partial class InvestorReportForm : Form
    {
        string sortParameter;
        public InvestorReportForm(string param)
        {
            this.sortParameter = param;
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

            if (sortParameter == "name")
            {
                reportViewer1.LocalReport.DataSources.Clear(); //clear report
                Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("InvestorsDS", Globals.GlobalInvestors); // set the datasource
                reportViewer1.LocalReport.DataSources.Add(dataset);
                dataset.Value = Globals.GlobalInvestors;
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            else
            {
                reportViewer1.LocalReport.DataSources.Clear(); //clear report
                Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("InvestorsDS", Globals.GlobalInvestors); // set the datasource
                reportViewer1.LocalReport.DataSources.Add(dataset);
                dataset.Value = Globals.GlobalInvestors.OrderBy(gi => gi.JoinDate);
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
