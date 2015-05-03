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
    public partial class AddInvestorForm : Form
    {
        public AddInvestorForm()
        {
            InitializeComponent();
        }


        private void AddInvestorForm_Load(object sender, EventArgs e)
        {

            //Default values for text boxes
            AddInvLastInvYearTextBox.Text = DateTime.Now.Year.ToString();


            //Setup the columns for the datagridview
            //Column 0: Date
            FIFLibrary.CalendarColumn DateColumn = new FIFLibrary.CalendarColumn();
            DateColumn.HeaderText = "Investment Date";

            //Column 1: Amount
            DataGridViewTextBoxColumn AmountColumn = new DataGridViewTextBoxColumn();
            AmountColumn.HeaderText = "Amount";

            //Column 2: Payment Type
            DataGridViewComboBoxColumn PaymentTypeColumn = new DataGridViewComboBoxColumn();
            PaymentTypeColumn.DataSource = new string[] { "check", "cash", "N/A" };
            PaymentTypeColumn.HeaderText = "Payment Type";
            PaymentTypeColumn.Name = "Payment Type";

            //Column 3: Check Number
            DataGridViewTextBoxColumn CheckNumberColumn = new DataGridViewTextBoxColumn();
            CheckNumberColumn.HeaderText = "Check Number";

            //Column 4: Credit To
            DataGridViewComboBoxColumn CreditToColumn = new DataGridViewComboBoxColumn();
            CreditToColumn.DataSource = new string[] { "general fund", "youth", "N/A" };
            CreditToColumn.HeaderText = "Credit To";
            CreditToColumn.Name = "Credit To";

            //Column 5: Youth Name
            DataGridViewComboBoxColumn YouthColumn = new DataGridViewComboBoxColumn();
            YouthColumn.DataSource = DBCommunication.GetYouthFullNames();
            YouthColumn.HeaderText = "Youth Name";
            YouthColumn.Name = "Youth Name";

            //Column 6: Reinvest
            DataGridViewCheckBoxColumn ReinvestColumn = new DataGridViewCheckBoxColumn();
            ReinvestColumn.HeaderText = "Reinvest";

            //add columns to datagridview
            InvDataGridView.Columns.Add(DateColumn);
            InvDataGridView.Columns.Add(AmountColumn);
            InvDataGridView.Columns.Add(PaymentTypeColumn);
            InvDataGridView.Columns.Add(CheckNumberColumn);
            InvDataGridView.Columns.Add(CreditToColumn);
            InvDataGridView.Columns.Add(YouthColumn);
            InvDataGridView.Columns.Add(ReinvestColumn);
        }

        private void InvestorZipTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }

        //The following methods restrict the type of input allowed in a text box
        private void InvestorStateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void InvestorStateTextBox_TextChanged(object sender, EventArgs e)
        {
            if (InvestorStateTextBox.Text != "")
            {
                InvestorStateTextBox.Text = InvestorStateTextBox.Text.ToUpper();
            }
        }





        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //First check for invalid cells on the datagrid
            foreach (DataGridViewRow row in InvDataGridView.SelectedRows)
            {
                if(checkForInvalidValues(row))
                {
                    return;
                }
            }

            //check to make sure that the required fields have been entered
            if (!RequiredFieldsAreFilledOut())
            {
                MessageBox.Show("Please fill out all required fields.");
                return;
            }

            //After all the user data has been verified, make sure the user is ready to save changes.
            var dialogResult = MessageBox.Show("Changes will be saved now.  Continue?", "Alert!", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if(!DBCommunication.SaveNewInvestor(InvestorFNTextBox.Text, InvestorLNTextBox.Text, InvestorAddressTextBox.Text,
                InvestorCityTextBox.Text, InvestorStateTextBox.Text, InvestorZipTextBox.Text, InvestorEmailTextBox.Text, InvestorPhoneMaskedTextBox.Text,
                InvestorDeceasedCheckBox.Checked, InvestorJoinDateDateTimePicker.Value, InvestorNotesRichTextBox.Text))
            {
                return; //error message supplied to user in the SaveNewInvestor() method
            }


            //Update the global list of investors to reflect the addition of the new investor
            Globals.GlobalInvestors = DBCommunication.GetInvestors();

            if (!InvDataGridView.Rows[0].IsNewRow)
            {
                List<Investment2> newInvestments = new List<Investment2>();
                int investorID = Globals.GlobalInvestors.Where(i => i.LabelName == InvestorFNTextBox.Text + " " + InvestorLNTextBox.Text).Single().InvestorID;
                FetchNewInvestments(newInvestments, investorID);

                int numSuccessfullySaved = DBCommunication.SaveNewInvestments(newInvestments);
                if(numSuccessfullySaved != newInvestments.Count)
                {
                    return;
                }

                PDFCreator pdfCreator = new PDFCreator(Globals.GlobalInvestors.Where(i => i.InvestorID == investorID).Single());
                bool savePDFSuccess = false;
                foreach (Investment2 i in newInvestments)
                {
                   savePDFSuccess = pdfCreator.createPDF(i, "saveOnly");
                    if(!savePDFSuccess)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show(string.Format("Save operation successfully completed."));
            Globals.rebindOnMainForm = true;
            this.Close();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to cancel?  All work will be lost.", "Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private bool checkForInvalidValues(DataGridViewRow row)
        {
            if(row.Cells[1].Value == null)
            {
                MessageBox.Show("A positive non-zero value must be entered for the amount column in row " + row.Index);
                return true;
            }
            int outAmount;
            if(Int32.TryParse(row.Cells[1].Value.ToString(), out outAmount))
            {
                if (outAmount < 1)
                {
                    MessageBox.Show("A positive non-zero value must be entered for the amount column in row " + row.Index);
                    return true;
                }
            }
            if (row.Cells[2].Value == null)
            {
                MessageBox.Show("A payment type must be selected for row " + row.Index);
                return true;
            }
            if (row.Cells[4].Value == null)
            {
                MessageBox.Show("You must select a value for 'Credit To' for row " + row.Index);
                return true;
            }

            if (row.Cells[5].Value == null && row.Cells[4].Value.ToString() == "youth")
            {
                MessageBox.Show("You must select a youth for row " + row.Index);
                return true;
            }
            if(row.Cells[6].Value == null)
            {
                MessageBox.Show("The value for 'Reinvest' for row " + row.Index + " cannot be null.");
                return true;
            }
            return false;
        }

        //Ensure that only numbers can be entered into amount and check number
        private void InvDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(AmountColumn_KeyPress);
            if (InvDataGridView.CurrentCell.ColumnIndex == 1 ||
                InvDataGridView.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(AmountColumn_KeyPress);
                }
            }
        }

        private void AmountColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void InvDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) // Force "youth name" to be read only if "credit to" is "general fund" or "N/A"
            {
                if (e.RowIndex >= 0)
                {
                    if (InvDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "youth")
                    {
                        InvDataGridView.Rows[e.RowIndex].Cells[5].ReadOnly = false;
                        InvDataGridView.Rows[e.RowIndex].Cells[5].Value = Globals.GlobalYouth.First().FullName;
                    }
                    else
                    {
                        InvDataGridView.Rows[e.RowIndex].Cells[5].ReadOnly = true;
                        InvDataGridView.Rows[e.RowIndex].Cells[5].Value = "";
                    }
                }
            }

            if (e.ColumnIndex == 2) //If "payment type" != "Check" force the "check" cell to be read-only
            {
                if (e.RowIndex >= 0)
                {
                    if (InvDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "check")
                    {
                        InvDataGridView.Rows[e.RowIndex].Cells[3].ReadOnly = false;
                    }
                    else
                    {
                        InvDataGridView.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                        InvDataGridView.Rows[e.RowIndex].Cells[3].Value = "";
                        InvDataGridView.Columns[3].ToolTipText = "Select 'check' in the 'Payment Type' to enter a check number.";
                    }
                }
            }
        }

        private void InvDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (InvDataGridView.CurrentCell is DataGridViewComboBoxCell)
            {
                InvDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                InvDataGridView.EndEdit();
            }
        }

        private void InvDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[4].Value = Globals.DefaultCreditToType;
            e.Row.Cells[2].Value = Globals.DefaultPaymentType;
            e.Row.Cells[1].Value = Globals.DefaultInvestmentAmount;
            e.Row.Cells[6].Value = "false";
        }


        private void saveAndEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //check to make sure that the required fields have been entered
            if (!RequiredFieldsAreFilledOut())
            {
                MessageBox.Show("Please fill out all required fields.");
                return;
            }

            if(InvDataGridView.Rows[0].IsNewRow)
            {
                MessageBox.Show("You have not entered any investments to email");
                return;
            }

            //check for invalid cells on the datagrid
            foreach (DataGridViewRow row in InvDataGridView.SelectedRows)
            {
                if (checkForInvalidValues(row))
                {
                    return;
                }
            }

            //After all the user data has been verified, make sure the user is ready to save changes.
            var dialogResult = MessageBox.Show("Changes will be saved now.  Continue?", "Alert!", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (!DBCommunication.SaveNewInvestor(InvestorFNTextBox.Text, InvestorLNTextBox.Text, InvestorAddressTextBox.Text,
                InvestorCityTextBox.Text, InvestorStateTextBox.Text, InvestorZipTextBox.Text, InvestorEmailTextBox.Text, InvestorPhoneMaskedTextBox.Text,
                InvestorDeceasedCheckBox.Checked, InvestorJoinDateDateTimePicker.Value, InvestorNotesRichTextBox.Text))
            {
                return; //error message supplied to user in the SaveNewInvestor() method
            }


            //Update the global list of investors to reflect the addition of the new investor
            Globals.GlobalInvestors = DBCommunication.GetInvestors();

            /*To create a new investment I need the investor's ID.  The investor's ID is not created until entered into
             *the DB for the first time.  That's why I have to fetch it from the DB now.
             */
            Investor2 newInvestor = Globals.GlobalInvestors.Where(i => i.LabelName == InvestorFNTextBox.Text + " " + InvestorLNTextBox.Text).Single();

            //The following variables track the number of successully emailed investments
            int numEmailAttempts = 0;

            List<Investment2> newInvestments = new List<Investment2>();
            if (!InvDataGridView.Rows[0].IsNewRow)
            {
                int investorID = Globals.GlobalInvestors.Where(i => i.LabelName == InvestorFNTextBox.Text + " " + InvestorLNTextBox.Text).Single().InvestorID;
                FetchNewInvestments(newInvestments, investorID);
                int numSuccessfullySaved = DBCommunication.SaveNewInvestments(newInvestments);
                if(numSuccessfullySaved != newInvestments.Count)
                {
                    return;
                }
            }
            Globals.rebindOnMainForm = true;

            //Now email the investments.  I'm emailing after saving all the investments.  It is important to save first,
            //because if emailing fails, the user has not lost the investment information and can attempt to re-email in the view/edit investor form.

            PDFCreator pdfCreator = new PDFCreator(newInvestor);
            foreach (Investment2 i in newInvestments)
            {
                pdfCreator.createPDF(i, "email");
                numEmailAttempts++;
            }

            MessageBox.Show(string.Format("Save operation was successful. The program has attempted to email {0} new investment certificate(s).  Please check your email account to verify they have been emailed.", numEmailAttempts));

            this.Close();
        }

        private void InvestorFNTextBox_Leave(object sender, EventArgs e)
        {
            InvestorLabelNameTextBox.Text = InvestorFNTextBox.Text + " " + InvestorLNTextBox.Text;
        }

        private void InvestorLNTextBox_TextChanged(object sender, EventArgs e)
        {
            InvestorLabelNameTextBox.Text = InvestorFNTextBox.Text + " " + InvestorLNTextBox.Text;
        }

        /*
         * The following is the click event for the "Save & New Investor" tool strip menu item
         * When clicked, the investor information will be saved to the database and any
         * investments will also be saved to the DB.  After the save operation is completed, 
         * a new add investor form will automatically open.
         */
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //First check for invalid cells on the datagrid
            foreach (DataGridViewRow row in InvDataGridView.SelectedRows)
            {
                if (checkForInvalidValues(row))
                {
                    return;
                }
            }

            //check to make sure that the required fields have been entered
            if (!RequiredFieldsAreFilledOut())
            {
                MessageBox.Show("Please fill out all required fields.");
                return;
            }

            //After all the user data has been verified, make sure the user is ready to save changes.
            var dialogResult = MessageBox.Show("Changes will be saved now.  Continue?", "Alert!", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (!DBCommunication.SaveNewInvestor(InvestorFNTextBox.Text, InvestorLNTextBox.Text, InvestorAddressTextBox.Text,
                InvestorCityTextBox.Text, InvestorStateTextBox.Text, InvestorZipTextBox.Text, InvestorEmailTextBox.Text, InvestorPhoneMaskedTextBox.Text,
                InvestorDeceasedCheckBox.Checked, InvestorJoinDateDateTimePicker.Value, InvestorNotesRichTextBox.Text))
            {
                return; //error message supplied to user in the SaveNewInvestor() method
            }

            //Update the global list of investors to reflect the addition of the new investor
            Globals.GlobalInvestors = DBCommunication.GetInvestors();

            if (!InvDataGridView.Rows[0].IsNewRow)
            {
                List<Investment2> newInvestments = new List<Investment2>();
                int investorID = Globals.GlobalInvestors.Where(i => i.LabelName == InvestorFNTextBox.Text + " " + InvestorLNTextBox.Text).Single().InvestorID;
                FetchNewInvestments(newInvestments, investorID);

                int numSuccessfullySaved = DBCommunication.SaveNewInvestments(newInvestments);
                if(numSuccessfullySaved != newInvestments.Count)
                {
                    return;
                }

                PDFCreator pdfCreator = new PDFCreator(Globals.GlobalInvestors.Where(i => i.InvestorID == investorID).Single());
                bool savePDFSuccess = false;
                foreach (Investment2 i in newInvestments)
                {
                    savePDFSuccess = pdfCreator.createPDF(i, "saveOnly");
                    if(!savePDFSuccess)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show(string.Format("Save operation successfully completed."));
            Globals.rebindOnMainForm = true;
            this.Close();
            AddInvestorForm AIF = new AddInvestorForm();
            AIF.Show();
        }

        private void AddInvestorForm_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void AddInvestorForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private bool RequiredFieldsAreFilledOut()
        {
            if (
                InvestorFNTextBox.Text == "" ||
                InvestorLNTextBox.Text == "" ||
                InvestorAddressTextBox.Text == "" ||
                InvestorCityTextBox.Text == "" ||
                InvestorStateTextBox.Text == "" ||
                InvestorZipTextBox.Text == ""
                )
            {
                return false;
            }
            return true;
        }

        private void FetchNewInvestments(List<Investment2> newInvestments, int investorID)
        {
            int youthID, outAmount;
            string reinvest = "";
            string checkNumber = "";
            foreach (DataGridViewRow row in InvDataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[3].Value != null)
                    {
                        checkNumber = row.Cells[3].Value.ToString();
                    }
                    if (Int32.TryParse(row.Cells[1].Value.ToString(), out outAmount))
                    {

                    }
                    if (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "")
                    {
                        youthID = Globals.GlobalYouth.Where(y => y.FullName == row.Cells[5].Value.ToString()).Single().YouthID;
                    }
                    else
                    {
                        youthID = -1;
                    }

                    if (row.Cells[6].Value.GetType() == typeof(String))
                    {
                        if (row.Cells[6].Value.ToString() == "true")
                        {
                            reinvest = "1";
                        }
                        else
                        {
                            reinvest = "0";
                        }
                    }
                    if (row.Cells[6].Value.GetType() == typeof(bool))
                    {
                        if ((bool)row.Cells[6].Value == true)
                        {
                            reinvest = "1";
                        }
                        else
                        {
                            reinvest = "0";
                        }
                    }
                    newInvestments.Add(new Investment2(
                            _investorID: investorID,
                            _date: row.Cells[0].Value.ToString(),
                            _amount: outAmount,
                            _creditTo: row.Cells[4].Value.ToString(),
                            _youthID: youthID,
                            _paymentType: row.Cells[2].Value.ToString(),
                            _checkNumber: checkNumber,
                            _reinvest: reinvest
                        ));
                }
            }
        }
    }
}
