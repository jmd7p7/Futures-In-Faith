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
    public partial class MainForm : Form
    {
        BindingSource investorsBD = new BindingSource();
        BindingSource youthBD = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region//Testing Code
            //Testing MyTests = new Testing();
            //MyTests.runPDFCreatorTest();
            #endregion

            //First check if this is the user's first time to log in
            if(DBCommunication.IsInitialLogIn())
            {
                InitialSetupForm ISF = new InitialSetupForm();
                ISF.Show();
            }
            DBCommunication.LoadSettings();

            Globals.GlobalInvestments = DBCommunication.GetInvestments();
            Globals.GlobalInvestors = DBCommunication.GetInvestors();
            Globals.GlobalYouth = DBCommunication.GetYouth();

            Globals.InitializeCertificateNumbers();
            Globals.GlobalCertificateNumbersToDelete = new List<string>();



            InvestorsListBox.DisplayMember = "LabelName";
            InvestorsListBox.ValueMember = "InvestorID";
            investorsBD.DataSource = Globals.GlobalInvestors;
            InvestorsListBox.DataSource = investorsBD;

            youthBD.DataSource = Globals.GlobalYouth;
            YouthListBox.DisplayMember = "FullName";
            YouthListBox.ValueMember = "YouthID";
            YouthListBox.DataSource = youthBD;

            //Setup the IndividualYouthComboBox used for the Youth Reports
            IndividualYouthComboBox.DataSource = youthBD;
            IndividualYouthComboBox.DisplayMember = "FullName";
            IndividualYouthComboBox.ValueMember = "FullName";


            StartDateDateTimePicker.Value = Globals.ProgramStartDate;
            EndDateDateTimePicker.Value = DateTime.Now;

            //Load the values for the user settings
            AdminEmailTextBox.Text = Globals.AdminEmail;
            AdminPasswordTextBox.Text = Globals.AdminPassword;
            ProgramStartDateTimePicker.Value = Globals.ProgramStartDate;
            ProgramEndDateTimePicker.Value = Globals.ProgramEndDate;
            DefaultAmountComboBox.SelectedItem = Globals.DefaultInvestmentAmount.ToString();
            DefaultCreditToComboBox.SelectedItem = Globals.DefaultCreditToType;
            DefaultPaymentTypeComboBox.SelectedItem = Globals.DefaultPaymentType;
            DefaultFilePathTextBox.Text = Globals.SaveFilePath;

            //These are used to track changes made to investors/investments/settings
            //to tell the form whether or not to rebind when the form becomes active again
            Globals.rebindOnMainForm = false;
            Globals.rebindYouthOnMainForm = false;
        }

        private void InvestorsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //ViewEditInvestorButton
        {
            if(Globals.GlobalInvestors.Count == 0)
            {
                MessageBox.Show("There are no investors in the database to edit.");
                return;
            }

            int outInvestorID;
            if(Int32.TryParse(InvestorsListBox.SelectedValue.ToString(), out outInvestorID))
            {
                try
                {
                    InvestorForm _investorForm = new InvestorForm(Globals.GlobalInvestors.Single(i => i.InvestorID == outInvestorID));
                    _investorForm.ShowDialog();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(string.Format("Unable to find the selected investor in the Database.  \nError Message: {0}", ex.Message));
                }
            }
            else
            {
                MessageBox.Show("Could not load investor because the Investor's ID is not an integer.");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)//AddInvestorButton
        {
            if (Globals.GlobalYouth.Count == 0)
            {
                MessageBox.Show("Please enter at least one youth in the database before adding investors.");
                return;
            }
            AddInvestorForm _addInvestorForm = new AddInvestorForm();
            _addInvestorForm.ShowDialog();
        }

        private void Youth_Enter(object sender, EventArgs e)
        {
            //youthBD.DataSource = DS.getYouthByIDAndName();
            //YouthListBox.DataSource = youthBD;
        }

        private void button3_Click(object sender, EventArgs e)//ViewEditYouthForm button
        {
            if(Globals.GlobalYouth.Count == 0)
            {
                MessageBox.Show("There are no youth in the database.");
                return;
            }
            ViewEditYouthForm _viewEditYouthForm = new ViewEditYouthForm((Youth)YouthListBox.SelectedItem);
            _viewEditYouthForm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddYouthForm _addYouthForm = new AddYouthForm();
            _addYouthForm.ShowDialog();
        }

        private void MainForm_Enter(object sender, EventArgs e)
        {

        }

        private void InvestorsTab_Enter(object sender, EventArgs e)
        {

        }




        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBCommunication.SaveCertificateNumber(Globals.GlobalCertificateNumbersToDelete);
        }



        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (Globals.rebindOnMainForm == true)
            {
                Globals.GlobalInvestments.Clear();
                Globals.GlobalInvestments = DBCommunication.GetInvestments();
                Globals.GlobalInvestors.Clear();
                Globals.GlobalInvestors = DBCommunication.GetInvestors();
                investorsBD.ResetBindings(false);
                investorsBD.DataSource = Globals.GlobalInvestors;
                Globals.rebindOnMainForm = false;
            }
            if (Globals.rebindYouthOnMainForm == true)
            {
                Globals.GlobalYouth.Clear();
                Globals.GlobalYouth = DBCommunication.GetYouth();
                youthBD.ResetBindings(false);
                youthBD.DataSource = Globals.GlobalYouth;
                Globals.rebindYouthOnMainForm = false;
            }
        }


        #region creating reports functionality
        private void CreateInvestorReportButton_Click(object sender, EventArgs e)
        {
            if(SortByFirstLastRadio.Checked)
            {
                InvestorReportForm RF = new InvestorReportForm("name");
                RF.Show();
            }
            else
            {
                InvestorReportForm RF = new InvestorReportForm("date");
                RF.Show();
            }
        }

        private void CreateStockReportButton_Click(object sender, EventArgs e)
        {
            if(SortByLastFirstForInvestmentsRadio.Checked)
            {
                InvestmentsReportForm RF = new InvestmentsReportForm("name", StartDateDateTimePicker.Value, EndDateDateTimePicker.Value);
                RF.Show();
            }
            else 
            {
                InvestmentsReportForm RF = new InvestmentsReportForm("certificateNumber", StartDateDateTimePicker.Value, EndDateDateTimePicker.Value);
                RF.Show();
            }
        }

        private void CreateYouthReportButton_Click(object sender, EventArgs e)
        {
            string sortParam;
            if (EverythingYouthSortRadio.Checked == true)
            {
                sortParam = "Everything";
            }
            else if (GeneralFundYouthSortRadio.Checked == true)
            {
                sortParam = "GeneralFundOnly";
            }
            else if (AllYouthYouthSortRadio.Checked == true)
            {
                sortParam = "YouthOnly";
            }
            else //Individual Youth is selected
            {
                sortParam = "IndividualYouth";
            }
            YouthReportForm YRF = new YouthReportForm(sortParam, StartDateDateTimePicker.Value, EndDateDateTimePicker.Value, IndividualYouthComboBox.SelectedValue.ToString());
            YRF.Show();
        }
        #endregion

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            DBCommunication.SaveSettings(AdminEmailTextBox.Text, AdminPasswordTextBox.Text, ProgramStartDateTimePicker.Value,
                ProgramEndDateTimePicker.Value, DefaultAmountComboBox.SelectedItem.ToString(), DefaultCreditToComboBox.SelectedItem.ToString(),
                DefaultPaymentTypeComboBox.SelectedItem.ToString(), DefaultFilePathTextBox.Text);
        }

        private void DefaultFilePathTextBox_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if(FBD.ShowDialog() == DialogResult.OK)
            {
                DefaultFilePathTextBox.Text = FBD.SelectedPath;
            }
        }



        #region Export to CVS functionality
        private bool ExportAllToCSV(string param)
        {

            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "CSV Files (*.csv)|*.csv";
            if(SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!System.IO.File.Exists(SFD.FileName))
                {
                    // Create a file to write to. 
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(SFD.FileName))
                    {
                        string _deceased;
                        if (param == "All")
                        {
                            foreach (Investor2 i in Globals.GlobalInvestors)
                            {
                                if (i.Deceased == true)
                                {
                                    _deceased = "true";
                                }
                                else
                                {
                                    _deceased = "false";
                                }
                                sw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, deceased: {9}",
                                    i.LabelName, i.Address, i.City, i.State, i.Zip, i.Email, i.Phone, i.JoinDate.ToShortDateString(), i.LastInvestYear, _deceased));
                            }
                        }
                        else if(param == "WithEmail")
                        {
                            foreach (Investor2 i in Globals.GlobalInvestors.Where(i=>i.Email != ""))
                            {
                                if (i.Deceased == true)
                                {
                                    _deceased = "true";
                                }
                                else
                                {
                                    _deceased = "false";
                                }
                                sw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, deceased: {9}",
                                    i.LabelName, i.Address, i.City, i.State, i.Zip, i.Email, i.Phone, i.JoinDate.ToShortDateString(), i.LastInvestYear, _deceased));
                            }
                        }
                        else if (param == "WithoutEmail")
                        {
                            foreach (Investor2 i in Globals.GlobalInvestors.Where(i => i.Email == ""))
                            {
                                if (i.Deceased == true)
                                {
                                    _deceased = "true";
                                }
                                else
                                {
                                    _deceased = "false";
                                }
                                sw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, deceased: {9}",
                                    i.LabelName, i.Address, i.City, i.State, i.Zip, i.Email, i.Phone, i.JoinDate.ToShortDateString(), i.LastInvestYear, _deceased));
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool ExportInvestorsWithoutEmailToCSV()
        {

            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "CSV Files (*.csv)|*.csv";
            SFD.FileName = "FIF_Investors No Email";
            if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Create a file to write to. 
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(SFD.FileName))
                {
                    string _deceased;
                    //first write headers
                    sw.WriteLine("Last Name, First Name, E-mail Address, Home Address, City, State, Zip, Phone, Join Date, Deceased, Label Name, Last InvYear");
                    foreach (Investor2 i in Globals.GlobalInvestors.Where(i => i.Email == ""))
                    {
                        if (i.Deceased == true)
                        {
                            _deceased = "true";
                        }
                        else
                        {
                            _deceased = "false";
                        }
                        sw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                            i.LastName, i.FirstName, i.Email, i.Address, i.City, i.State, i.Zip, i.Phone, i.JoinDate.ToShortDateString(), _deceased, i.LastName, i.LastInvestYear));
                    }
                }
            }
            return false;
        }

        private bool ExportInvestorsWithEmailToCSV()
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "CSV Files (*.csv)|*.csv";
            SFD.FileName = "FIF_Investors With Email";
            if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Create a file to write to. 
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(SFD.FileName))
                {
                    string _deceased;
                    //first write headers
                    sw.WriteLine("Last Name, First Name, E-mail Address, Home Address, City, State, Zip, Phone, Join Date, Deceased, Label Name, Last InvYear");
                    foreach (Investor2 i in Globals.GlobalInvestors.Where(i => i.Email != ""))
                    {
                        if (i.Deceased == true)
                        {
                            _deceased = "true";
                        }
                        else
                        {
                            _deceased = "false";
                        }
                        sw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                            i.LastName, i.FirstName, i.Email, i.Address, i.City, i.State, i.Zip, i.Phone, i.JoinDate.ToShortDateString(), _deceased, i.LastName, i.LastInvestYear));
                    }
                }
            }
            return false;
        }

        private bool ExportAllInvestorsToCSV()
        {

            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "CSV Files (*.csv)|*.csv";
            SFD.FileName = "FIF_All Investors";
            if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Create a file to write to. 
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(SFD.FileName))
                {
                    string _deceased;
                    //first write headers
                    sw.WriteLine("Last Name, First Name, E-mail Address, Home Address, City, State, Zip, Phone, Join Date, Deceased, Label Name, Last InvYear");
                    foreach (Investor2 i in Globals.GlobalInvestors)
                    {
                        if (i.Deceased == true)
                        {
                            _deceased = "true";
                        }
                        else
                        {
                            _deceased = "false";
                        }
                        sw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                            i.LastName, i.FirstName, i.Email, i.Address, i.City, i.State, i.Zip, i.Phone, i.JoinDate.ToShortDateString(), _deceased, i.LastName, i.LastInvestYear));
                    }
                }
            }
            return false;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if(SortByInvestorsExportRadio.Checked == true)
            {
                ExportAllInvestorsToCSV();
            }
            else if(SortByInvWithEmailExportRadio.Checked == true)
            {
                ExportInvestorsWithEmailToCSV();
            }
            else if (SortByInvWithoutEmailExportRadio.Checked == true)
            {
                ExportInvestorsWithoutEmailToCSV();
            }
        }
        #endregion

        private void InvestorsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Globals.GlobalInvestors.Count == 0)
            {
                MessageBox.Show("There are no investors in the database to edit.");
                return;
            }

            int outInvestorID;
            if (Int32.TryParse(InvestorsListBox.SelectedValue.ToString(), out outInvestorID))
            {
                try
                {
                    InvestorForm _investorForm = new InvestorForm(Globals.GlobalInvestors.Single(i => i.InvestorID == outInvestorID));
                    _investorForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Unable to find the selected investor in the Database.  \nError Message: {0}", ex.Message));
                }
            }
            else
            {
                MessageBox.Show("Could not load investor because the Investor's ID is not an integer.");
            }
        }
    }
}
