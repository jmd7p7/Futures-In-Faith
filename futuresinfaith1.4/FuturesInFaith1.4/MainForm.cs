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

            Globals.GlobalInvestments = DBCommunication.GetInvestments();
            Globals.GlobalInvestors = DBCommunication.GetInvestors();
            Globals.GlobalYouth = DBCommunication.GetYouth();

            Globals.InitializeCertificateNumbers();
            Globals.GlobalCertificateNumbersToDelete = new List<string>();
            Globals.rebindOnMainForm = false;
            Globals.rebindYouthOnMainForm = false;


            InvestorsListBox.DisplayMember = "LabelName";
            InvestorsListBox.ValueMember = "InvestorID";
            investorsBD.DataSource = Globals.GlobalInvestors;
            InvestorsListBox.DataSource = investorsBD;

            youthBD.DataSource = Globals.GlobalYouth;
            YouthListBox.DisplayMember = "FullName";
            YouthListBox.ValueMember = "YouthID";
            YouthListBox.DataSource = youthBD;
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
            if(checkForOpenYouthForms())
            {
                MessageBox.Show("Adding/editing investors and youth at the same time is not allowed.  Please close any open youth forms.");
                return;
            }
            int outInvestorID;
            if(Int32.TryParse(InvestorsListBox.SelectedValue.ToString(), out outInvestorID))
            {
                try
                {
                    InvestorForm _investorForm = new InvestorForm(Globals.GlobalInvestors.Single(i => i.InvestorID == outInvestorID));
                    _investorForm.Show();
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
            if (checkForOpenYouthForms())
            {
                MessageBox.Show("Adding/editing investors and youth at the same time is not allowed.  Please close any open youth forms.");
                return;
            }
            AddInvestorForm _addInvestorForm = new AddInvestorForm();
            _addInvestorForm.Show();
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
            if (checkForOpenInvestorForms())
            {
                MessageBox.Show("Adding/editing youth and investors at the same time is not allowed.  Please close any open investor forms.");
                return;
            }
            ViewEditYouthForm _viewEditYouthForm = new ViewEditYouthForm((Youth)YouthListBox.SelectedItem);
            _viewEditYouthForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(checkForOpenInvestorForms())
            {
                MessageBox.Show("Adding/editing youth and investors at the same time is not allowed.  Please close any open investor forms.");
                return;
            }
            AddYouthForm _addYouthForm = new AddYouthForm();
            _addYouthForm.Show();
        }

        private void MainForm_Enter(object sender, EventArgs e)
        {

        }

        private void InvestorsTab_Enter(object sender, EventArgs e)
        {
            //investorsBD.DataSource = DS.getInvestorsByIdAndName();
            //InvestorsListBox.DataSource = investorsBD;
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

        private bool checkForOpenYouthForms()
        {
            FormCollection FC = Application.OpenForms;
            foreach(Form f in FC)
            {
                if (f.Name == "ViewEditYouthForm" || f.Name == "AddYouthForm")
                {
                    return true;
                }
            }
            return false;
        }

        private bool checkForOpenInvestorForms()
        {
            FormCollection FC = Application.OpenForms;
            foreach (Form f in FC)
            {
                if (f.Name == "AddInvestorForm" || f.Name == "InvestorForm")
                {
                    return true;
                }
            }
            return false;
        }

    }
}
