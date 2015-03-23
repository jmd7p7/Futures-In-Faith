﻿using System;
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

            /*


            //Configure the datagridview

            //Set ID & foreign key fields to displayed = false
            AddInvestorDataGridView.Columns[0].Visible = false;
            AddInvestorDataGridView.Columns[1].Visible = false;
            AddInvestorDataGridView.Columns[2].Visible = false;
            AddInvestorDataGridView.Columns[4].Visible = false;
            AddInvestorDataGridView.Columns[5].Visible = false;
            AddInvestorDataGridView.Columns[6].Visible = false;
            AddInvestorDataGridView.Columns[7].Visible = false;

            //Add named columns representing the foreign key relationships
            DataGridViewComboBoxColumn CreditToColumn = new DataGridViewComboBoxColumn();
            CreditToColumn.HeaderText = "Credit To";
            CreditToColumn.Name = "Credit To";
            CreditToColumn.DataSource = new string[] { "general fund", "youth", "N/A" };


            DataGridViewComboBoxColumn YouthColumn = new DataGridViewComboBoxColumn();
            YouthColumn.HeaderText = "Youth Name";
            YouthColumn.Name = "Youth Name";
            YouthColumn.DataSource = DBCommunication.GetYouthFullNames();


            DataGridViewComboBoxColumn PaymentTypeColumn = new DataGridViewComboBoxColumn();
            PaymentTypeColumn.HeaderText = "Payment Type";
            PaymentTypeColumn.Name = "Payment Type";
            PaymentTypeColumn.DataSource = new string[] { "check", "cash", "N/A" };


            FIFLibrary.CalendarColumn DateColumn = new FIFLibrary.CalendarColumn();
            DateColumn.HeaderText = "Investment Date";


            //Add other column properties
            AddInvestorDataGridView.Columns[2].ToolTipText = "A valid date must be entered in the format: mm/dd/yyyy.  Example: 7/16/2015";


            AddInvestorDataGridView.Columns.Add(CreditToColumn);
            AddInvestorDataGridView.Columns.Add(YouthColumn);
            AddInvestorDataGridView.Columns.Add(PaymentTypeColumn);
            AddInvestorDataGridView.Columns.Add(DateColumn);

            //Reorder the columns in the table

            AddInvestorDataGridView.Columns[13].DisplayIndex = 0; // Date
            AddInvestorDataGridView.Columns[3].DisplayIndex = 1; // Amount
            AddInvestorDataGridView.Columns["Payment Type"].DisplayIndex = 2; // PaymentType
            AddInvestorDataGridView.Columns[8].DisplayIndex = 3; // CheckNumber
            AddInvestorDataGridView.Columns["Credit To"].DisplayIndex = 4; // CreditTo
            AddInvestorDataGridView.Columns["Youth Name"].DisplayIndex = 5; // Youth
            AddInvestorDataGridView.Columns[9].DisplayIndex = 6; // Reinvest
            AddInvestorDataGridView.Columns[0].DisplayIndex = 7;
            AddInvestorDataGridView.Columns[1].DisplayIndex = 8;
            AddInvestorDataGridView.Columns[5].DisplayIndex = 9;
            AddInvestorDataGridView.Columns[4].DisplayIndex = 10;
            AddInvestorDataGridView.Columns[6].DisplayIndex = 11;
            AddInvestorDataGridView.Columns[7].DisplayIndex = 12;
            AddInvestorDataGridView.Columns[2].DisplayIndex = 13;

            
             //   When it's all said and done the AddInvestorDataGridView should be formatted as follows:
             //* Column 0: InvestmentID
             //* Column 1: InvestorID
             //* Column 2: Date
             //* Column 3: Amount (Display index 1)
             //* Column 4: Certificate Number
             //* Column 5: CreditTo
             //* Column 6: YouthID
             //* Column 7: PaymentType
             //* Column 8: CheckNumber    (Display index 3)
             //* Column 9: Reinvest     (Display index 6)
             //* Column 10: Credit To   (Display index 4) 
             //* Column 11: Youth Name    (Display index 5)
             //* Column 12: Payment Type    (Display index 2)
             //* Column 13: Investment Date  (Display index 0)
             */
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

            //Alert the user if user has entered investments but not selected any for saving
            if (InvDataGridView.Rows.Count > 1 && InvDataGridView.SelectedRows.Count == 0)
            {
                var result = MessageBox.Show("You have not selected any investments to save.  Do you wish to continue saving only the investor?", "No Investments Selected!", MessageBoxButtons.YesNo);
                if(result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            //check to make sure that the required investor fields have been entered
            if (
                InvestorFNTextBox.Text == "" ||
                InvestorLNTextBox.Text == "" ||
                InvestorAddressTextBox.Text == "" ||
                InvestorCityTextBox.Text == "" ||
                InvestorStateTextBox.Text == "" ||
                InvestorZipTextBox.Text == ""
                )
            {
                MessageBox.Show("Please fill out all required fields for the investor.");
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


            if (InvDataGridView.SelectedRows.Count > 0)
            {
                List<Investment2> newInvestments = new List<Investment2>();
                int youthID, outAmount;
                string reinvest = "";
                string checkNumber = "";
                int investorID = Globals.GlobalInvestors.Where(i => i.LabelName == InvestorLNTextBox.Text + ", " + InvestorFNTextBox.Text).Single().InvestorID;
                foreach (DataGridViewRow row in InvDataGridView.SelectedRows)
                {
                    if(row.Cells[3].Value != null)
                    {
                        checkNumber = row.Cells[3].Value.ToString();
                    }
                    if(Int32.TryParse(row.Cells[1].Value.ToString(), out outAmount))
                    {

                    }
                    if(row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "")
                    {
                        youthID = Globals.GlobalYouth.Where(y => y.FullName == row.Cells[5].Value.ToString()).Single().YouthID;
                    }
                    else
                    {
                        youthID = -1;
                    }
                    
                    if(row.Cells[6].Value.GetType() == typeof(String))
                    {
                        if(row.Cells[6].Value.ToString() == "true")
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
                DBCommunication.SaveNewInvestments(newInvestments);                
            }
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


        //private void AddInvestorDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    e.Control.KeyPress -= new KeyPressEventHandler(AmountColumn_KeyPress);
        //    if (AddInvestorDataGridView.CurrentCell.ColumnIndex == 3 ||
        //        AddInvestorDataGridView.CurrentCell.ColumnIndex == 8) 
        //    {
        //        TextBox tb = e.Control as TextBox;
        //        if (tb != null)
        //        {
        //            tb.KeyPress += new KeyPressEventHandler(AmountColumn_KeyPress);
        //        }
        //    }
        //}



        //private void AddInvestorDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        //{
        //    e.Row.Cells[10].Value = Globals.DefaultCreditToType;
        //    e.Row.Cells[12].Value = Globals.DefaultPaymentType;
        //    e.Row.Cells[3].Value = Globals.DefaultInvestmentAmount;
        //}

        //private void AddInvestorDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if(e.ColumnIndex == 10)
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            if (AddInvestorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "youth")
        //            {
        //                AddInvestorDataGridView.Rows[e.RowIndex].Cells[11].ReadOnly = false;
        //                AddInvestorDataGridView.Rows[e.RowIndex].Cells[11].Value = Globals.GlobalYouth.First().FullName;
        //            }
        //            else
        //            {
        //                AddInvestorDataGridView.Rows[e.RowIndex].Cells[11].ReadOnly = true;
        //                AddInvestorDataGridView.Rows[e.RowIndex].Cells[11].Value = "";
        //            }
        //        }
        //    }

        //    if(e.ColumnIndex == 12)
        //    {
        //        if(e.RowIndex >= 0)
        //        {
        //            if(AddInvestorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "check")
        //            {
        //                AddInvestorDataGridView.Rows[e.RowIndex].Cells[8].ReadOnly = false;
        //            }
        //            else
        //            {
        //                AddInvestorDataGridView.Rows[e.RowIndex].Cells[8].ReadOnly = true;
        //                AddInvestorDataGridView.Rows[e.RowIndex].Cells[8].Value = "";
        //                AddInvestorDataGridView.Columns[8].ToolTipText = "Select 'check' in the 'Payment Type' to enter a check number.";
        //            }
        //        }
        //    }
        //}



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

        //private void AddInvestorDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    if(AddInvestorDataGridView.CurrentCell is DataGridViewComboBoxCell)
        //    {
        //        AddInvestorDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //        AddInvestorDataGridView.EndEdit();
        //    }
        //}

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
    }
}