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
    public partial class InitialSetupForm : Form
    {
        bool setupComplete = false;
        public InitialSetupForm()
        {
            InitializeComponent();
        }

        private void InitialSetupForm_Load(object sender, EventArgs e)
        {
            ProgramStartDateTimePicker.Value = DateTime.Now;
            ProgramEndDateTimePicker.Value = DateTime.Now;
        }

        private void DefaultFilePathTextBox_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if(FBD.ShowDialog() == DialogResult.OK)
            {
                DefaultFilePathTextBox.Text = FBD.SelectedPath;
            }
        }

        private void CreateSettingsButton_Click(object sender, EventArgs e)
        {
            if(AdminEmailTextBox.Text == "" || AdminPasswordTextBox.Text == "" || DefaultFilePathTextBox.Text == "")
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }
            if(ProgramStartDateTimePicker.Value > ProgramEndDateTimePicker.Value)
            {
                MessageBox.Show("The start date must be less than the end date.");
                return;
            }

            if(!FIFLibrary.DBCommunication.SaveInitialSettings(AdminEmailTextBox.Text, AdminPasswordTextBox.Text, ProgramStartDateTimePicker.Value,
                ProgramEndDateTimePicker.Value, DefaultAmountComboBox.SelectedItem.ToString(), DefaultCreditToComboBox.SelectedItem.ToString(),
                DefaultPaymentTypeComboBox.SelectedItem.ToString(), DefaultFilePathTextBox.Text, false))
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Your settings have been saved to the database.");
                FIFLibrary.Globals.IsFirstLogin = false;
                setupComplete = true;
                this.Close();
            }
        }

        private void InitialSetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!setupComplete)
            {
                MessageBox.Show("Initial setup must be completed before the applications will run.  Please restart the application and complete the initial setup.", "Alert!");
                Application.Exit();
            }

        }
    }
}
