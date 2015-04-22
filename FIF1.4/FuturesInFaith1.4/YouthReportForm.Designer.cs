namespace FuturesInFaith1._4
{
    partial class YouthReportForm
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
            this.YouthReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.YouthReportItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.YouthReportItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // YouthReportViewer
            // 
            this.YouthReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "YouthDS";
            reportDataSource1.Value = this.YouthReportItemBindingSource;
            this.YouthReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.YouthReportViewer.LocalReport.ReportEmbeddedResource = "FuturesInFaith1._4.Reports.Youth.rdlc";
            this.YouthReportViewer.Location = new System.Drawing.Point(0, 0);
            this.YouthReportViewer.Name = "YouthReportViewer";
            this.YouthReportViewer.Size = new System.Drawing.Size(688, 282);
            this.YouthReportViewer.TabIndex = 0;
            // 
            // YouthReportItemBindingSource
            // 
            this.YouthReportItemBindingSource.DataSource = typeof(FIFLibrary.YouthReportItem);
            // 
            // YouthReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 282);
            this.Controls.Add(this.YouthReportViewer);
            this.Name = "YouthReportForm";
            this.Text = "YouthReportForm";
            this.Load += new System.EventHandler(this.YouthReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YouthReportItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer YouthReportViewer;
        private System.Windows.Forms.BindingSource YouthReportItemBindingSource;
    }
}