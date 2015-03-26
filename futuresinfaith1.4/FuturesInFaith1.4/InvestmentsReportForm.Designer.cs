namespace FuturesInFaith1._4
{
    partial class InvestmentsReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.InvestmentsReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Investor2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InvestmentReportItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Investor2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvestmentReportItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // InvestmentsReportViewer
            // 
            this.InvestmentsReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "InvestmentDS";
            reportDataSource1.Value = this.InvestmentReportItemBindingSource;
            this.InvestmentsReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.InvestmentsReportViewer.LocalReport.ReportEmbeddedResource = "FuturesInFaith1._4.Reports.Investments.rdlc";
            this.InvestmentsReportViewer.Location = new System.Drawing.Point(0, 0);
            this.InvestmentsReportViewer.Name = "InvestmentsReportViewer";
            this.InvestmentsReportViewer.Size = new System.Drawing.Size(1009, 380);
            this.InvestmentsReportViewer.TabIndex = 0;
            // 
            // Investor2BindingSource
            // 
            this.Investor2BindingSource.DataSource = typeof(FIFLibrary.Investor2);
            // 
            // InvestmentReportItemBindingSource
            // 
            this.InvestmentReportItemBindingSource.DataSource = typeof(FIFLibrary.InvestmentReportItem);
            // 
            // InvestmentsReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 380);
            this.Controls.Add(this.InvestmentsReportViewer);
            this.Name = "InvestmentsReportForm";
            this.Text = "Investments Report";
            this.Load += new System.EventHandler(this.InvestmentsReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Investor2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvestmentReportItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer InvestmentsReportViewer;
        private System.Windows.Forms.BindingSource Investor2BindingSource;
        private System.Windows.Forms.BindingSource InvestmentReportItemBindingSource;
    }
}