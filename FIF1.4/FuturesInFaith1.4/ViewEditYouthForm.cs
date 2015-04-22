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
    public partial class ViewEditYouthForm : Form
    {
        Youth selectedYouth;
        public ViewEditYouthForm(Youth youth)
        {
            InitializeComponent();
            selectedYouth = youth;
        }

        private void ViewEditYouthForm_Load(object sender, EventArgs e)
        {
            EditYouthFirstNameTextBox.DataBindings.Add("Text", selectedYouth, "FirstName");
            EditYouthLastNameTextBox.DataBindings.Add("Text", selectedYouth, "LastName");
            EditYouthFullNameTextBox.DataBindings.Add("Text", selectedYouth, "FullName");
            EditYouthIsActiveCheckBox.DataBindings.Add("Checked", selectedYouth, "IsActive");
        }

        private void button1_Click(object sender, EventArgs e) //save changes button
        {
            if(EditYouthFirstNameTextBox.Text == "" || EditYouthLastNameTextBox.Text == "" || EditYouthFullNameTextBox.Text == "")
            {
                MessageBox.Show("Please fill out all fields before saving.");
                return;
            }
            if (EditYouthFullNameTextBox.Text != EditYouthLastNameTextBox.Text + ", " + EditYouthFirstNameTextBox.Text)
            {
                var result = MessageBox.Show("First and last names do not match full name.  Save anyway?", "Alert!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            DBCommunication.UpdateYouth(selectedYouth);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you wish to cancel?  All changes will be lost.", "Alert!", MessageBoxButtons.YesNo);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditYouthFirstNameTextBox.Text == "" || EditYouthLastNameTextBox.Text == "" || EditYouthFullNameTextBox.Text == "")
            {
                MessageBox.Show("Please fill out all fields before saving.");
                return;
            }
            if (EditYouthFullNameTextBox.Text != EditYouthLastNameTextBox.Text + ", " + EditYouthFirstNameTextBox.Text)
            {
                var result = MessageBox.Show("First and last names do not match full name.  Save anyway?", "Alert!", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            DBCommunication.UpdateYouth(selectedYouth);
            this.Close();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you wish to cancel?  All changes will be lost.", "Alert!", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
