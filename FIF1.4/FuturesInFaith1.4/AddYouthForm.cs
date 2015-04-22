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
    public partial class AddYouthForm : Form
    {
        public AddYouthForm()
        {
            InitializeComponent();
        }


        private void AddYouthForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void AddYouthForm_Load(object sender, EventArgs e)
        {         
            foreach (Form f in Application.OpenForms)
            {
                if(f.Name == "AddYouthForm" && f != this)
                {
                    f.Close();
                }
            }
        }

        private void AddYouthForm_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void AddYouthForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void saveNewYouthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AddYouthFirstNameTextBox.Text == "" || AddYouthLastNameTextBox.Text == "")
            {
                MessageBox.Show("Please enter a first and last name.");
            }
            else
            {
                if (Globals.GlobalYouth.Exists(y => y.FullName == AddYouthLastNameTextBox.Text + ", " + AddYouthFirstNameTextBox.Text))
                {
                    MessageBox.Show(string.Format("The youth '{0}' already exists in the database.", AddYouthLastNameTextBox.Text + ", " + AddYouthFirstNameTextBox.Text));
                }
                else
                {
                    if (DBCommunication.AddNewYouth(AddYouthFirstNameTextBox.Text, AddYouthLastNameTextBox.Text))
                    {
                        this.Close();
                        AddYouthForm _addYouthForm = new AddYouthForm();
                        _addYouthForm.Show();
                    }
                }
            }
        }

        private void saveCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AddYouthFirstNameTextBox.Text == "" || AddYouthLastNameTextBox.Text == "")
            {
                MessageBox.Show("Please enter a first and last name.");
            }
            else
            {
                if (Globals.GlobalYouth.Exists(y => y.FullName == AddYouthLastNameTextBox.Text + ", " + AddYouthFirstNameTextBox.Text))
                {
                    MessageBox.Show(string.Format("The youth '{0}' already exists in the database.", AddYouthLastNameTextBox.Text + ", " + AddYouthFirstNameTextBox.Text));
                }
                else
                {
                    if (DBCommunication.AddNewYouth(AddYouthFirstNameTextBox.Text, AddYouthLastNameTextBox.Text))
                    {
                        this.Close();
                    }
                }
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close this form?  All work will be lost.", "Cancel alert!", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
