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

        private void AddYouthCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddYouthSubmitButton_Click(object sender, EventArgs e)
        {
            if(AddYouthFirstNameTextBox.Text == "" || AddYouthLastNameTextBox.Text == "")
            {
                MessageBox.Show("Please enter a first and last name.");
            }
            else
            {
               if(Globals.GlobalYouth.Exists(y=>y.FullName == AddYouthLastNameTextBox.Text + ", " + AddYouthFirstNameTextBox.Text))
               {
                   MessageBox.Show(string.Format("The youth '{0}' already exists in the database.", AddYouthLastNameTextBox.Text + ", " + AddYouthFirstNameTextBox.Text));
               }
               else
               {
                   if(DBCommunication.AddNewYouth(AddYouthFirstNameTextBox.Text, AddYouthLastNameTextBox.Text))
                   {
                       this.Close();
                   }
               }
            }
        }
    }
}
