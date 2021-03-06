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
    public partial class InvestorForm : Form
    {
        Investor2 selectedInvestor;
        int startingInvestmentsCount;
        public InvestorForm(Investor2 investor)
        {
            InitializeComponent();
            selectedInvestor = investor;
        }

        private void StateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void InvestorForm_Load(object sender, EventArgs e)
        {
            //Find the number of investments associated with this investor.  If the user adds investments, 
            //user's LastInvestYear will need to be updated
            startingInvestmentsCount = Globals.GlobalInvestments.Where(i => i.InvestorID == selectedInvestor.InvestorID).Count();


            //Databind the textboxes to the investor
            FirstNameTextBox.DataBindings.Add("Text", selectedInvestor, "FirstName");
            LastNameTextBox.DataBindings.Add("Text", selectedInvestor, "LastName");
            AddressTextBox.DataBindings.Add("Text", selectedInvestor, "Address");
            CityTextBox.DataBindings.Add("Text", selectedInvestor, "City");
            StateTextBox.DataBindings.Add("Text", selectedInvestor, "State");
            ZipTextBox.DataBindings.Add("Text", selectedInvestor, "Zip");
            EmailTextBox.DataBindings.Add("Text", selectedInvestor, "Email");
            PhoneMaskedTextBox.DataBindings.Add("Text", selectedInvestor, "Phone");
            JoinDateTimePicker.DataBindings.Add("Value", selectedInvestor, "JoinDate");
            LastInvYearTextBox.DataBindings.Add("Text", selectedInvestor, "LastInvestYear");
            NotesRichTextBox.DataBindings.Add("Text", selectedInvestor, "Notes");
            LabelNameTextBox.DataBindings.Add("Text", selectedInvestor, "LabelName");
            InvestorDeceasedCheckBox.DataBindings.Add("Checked", selectedInvestor, "Deceased");

            //set properties for textboxes
            LastInvYearTextBox.ReadOnly = true;
            
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

            //Column 7: Certificate Number
            DataGridViewTextBoxColumn CertificateNumberColumn = new DataGridViewTextBoxColumn();
            CertificateNumberColumn.HeaderText = "Certificate Number";
            CertificateNumberColumn.ReadOnly = true;

            //Column 8: InvestmentID (display only - used for tracking the investmentID)
            DataGridViewTextBoxColumn InvestmentIDColumn = new DataGridViewTextBoxColumn();
            InvestmentIDColumn.Visible = false;

            //Column 9: IsNewInvestment (not visible, used for tracking new vs old investments)
            DataGridViewTextBoxColumn IsNewInvestmentColumn = new DataGridViewTextBoxColumn();
            IsNewInvestmentColumn.Visible = false;

            InvestmentsDataGridView.Columns.Add(DateColumn);
            InvestmentsDataGridView.Columns.Add(AmountColumn);
            InvestmentsDataGridView.Columns.Add(PaymentTypeColumn);
            InvestmentsDataGridView.Columns.Add(CheckNumberColumn);
            InvestmentsDataGridView.Columns.Add(CreditToColumn);
            InvestmentsDataGridView.Columns.Add(YouthColumn);
            InvestmentsDataGridView.Columns.Add(ReinvestColumn);
            InvestmentsDataGridView.Columns.Add(CertificateNumberColumn);
            InvestmentsDataGridView.Columns.Add(InvestmentIDColumn);
            InvestmentsDataGridView.Columns.Add(IsNewInvestmentColumn);

            foreach (Investment2 i in Globals.GlobalInvestments.Where(i => i.InvestorID == selectedInvestor.InvestorID))
            {
                string YouthName = "";
                if(i.YouthID != -1)
                {
                    YouthName = Globals.GlobalYouth.Where(y => y.YouthID == i.YouthID).Select(y => y.FullName).Single();
                }

                InvestmentsDataGridView.Rows.Add(i.Date, i.Amount, i.PaymentType, i.CheckNumber, i.CreditTo, 
                    YouthName, i.Reinvst, i.CertificateNumber, i.InvestmentID, "false");
                if(i.YouthID == -1)
                {
                    InvestmentsDataGridView.Rows[InvestmentsDataGridView.Rows.Count-2].Cells[5].ReadOnly = true;
                }
            }
        }

 
        //For this save option, the user wishes to save any changes made to the investor, including
        //changes made to the selected investments (may be new investments).
        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Multiple saves are potentially going on.  An investor's info is being saved,
             new investments may be saved, and updates to old investments may be saved.  The following
             variables track which save operations were successfully completed so as to give the user
             a helpful error message should something go wrong.*/


            //check to make sure that the required fields have been entered
            if (!RequiredFieldsAreFilledOut())
            {
                MessageBox.Show("Please fill out all required fields.");
                return;
            }

            if (LabelNameTextBox.Text != FirstNameTextBox.Text + " " + LastNameTextBox.Text)
            {
                var result = MessageBox.Show("The label name does not match the first and last name.  Save changes anyway?", "Name Mis-match Alert!", MessageBoxButtons.YesNo);
                if(result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            if(InvestmentsDataGridView.SelectedRows.Count == 0)
            {
                var result = MessageBox.Show("You have not selected any investments to update/add.  Save anyway?", "Alert!", MessageBoxButtons.YesNo);
                if(result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            //First check for invalid cells on the datagrid
            foreach (DataGridViewRow row in InvestmentsDataGridView.SelectedRows)
            {
                if(checkForInvalidValues(row))
                {
                    return;
                }
            }

            string lastInvestYear = LastInvYearTextBox.Text;
            List<Investment2> newInvestments = new List<Investment2>();
            List<Investment2> updatedInvestments = new List<Investment2>();

            FetchNewAndUpdatedInvestments(newInvestments, updatedInvestments, lastInvestYear);


            //Update the investor's information in the DB
            if (!DBCommunication.UpdateInvestor(selectedInvestor.InvestorID, FirstNameTextBox.Text, LastNameTextBox.Text, AddressTextBox.Text,
                CityTextBox.Text, StateTextBox.Text, ZipTextBox.Text, EmailTextBox.Text, PhoneMaskedTextBox.Text, InvestorDeceasedCheckBox.Checked,
                JoinDateTimePicker.Value, NotesRichTextBox.Text, LabelNameTextBox.Text, lastInvestYear))
            {
                return;
            }

            int numNewInvestementsSaved = 0;
            if (newInvestments.Count > 0)
            {
                numNewInvestementsSaved = DBCommunication.SaveNewInvestments(newInvestments);
                if (numNewInvestementsSaved == 0)
                {
                    MessageBox.Show("Any updates made to the investor were saved to the database.  Selected investments were not saved to the database.");
                    return;
                }
            }

            int numUpdatedInvestmentsSaved = 0;
            if (updatedInvestments.Count > 0)
            {
                numUpdatedInvestmentsSaved = DBCommunication.UpdateInvestments(updatedInvestments);
                if (numUpdatedInvestmentsSaved == 0)
                {
                    MessageBox.Show("Any updates made to the investor were saved to the database.  Any new investments may have been saved to the database but updated investments were not saved.");
                    return;
                }
            }

            PDFCreator creator = new PDFCreator(selectedInvestor);
            bool savePDFSuccess = false;
            foreach (Investment2 i2 in newInvestments)
            {
                savePDFSuccess = creator.createPDF(i2, "saveOnly");
                if(!savePDFSuccess)
                {
                    return;
                }
            }

            foreach (Investment2 i2 in updatedInvestments)
            {
                savePDFSuccess = creator.createPDF(i2, "saveOnly");
                if (!savePDFSuccess)
                {
                    return;
                }
            }

            MessageBox.Show(string.Format("Save operation successfully completed."));
            Globals.rebindOnMainForm = true;
            this.Close();
        }

        private void InvestmentsDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(AmountColumn_KeyPress);
            if (InvestmentsDataGridView.CurrentCell.ColumnIndex == 1 ||
                InvestmentsDataGridView.CurrentCell.ColumnIndex == 3)
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


        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel?  All work will be lost.", "Cancel alert!", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ZipTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }

        private void InvestmentsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex >= 0)
                {
                    if (InvestmentsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "youth")
                    {
                        InvestmentsDataGridView.Rows[e.RowIndex].Cells[5].ReadOnly = false;
                        InvestmentsDataGridView.Rows[e.RowIndex].Cells[5].Value = Globals.GlobalYouth.First().FullName;
                    }
                    else
                    {
                        InvestmentsDataGridView.Rows[e.RowIndex].Cells[5].ReadOnly = true;
                        InvestmentsDataGridView.Rows[e.RowIndex].Cells[5].Value = "";
                    }
                }
            }

            if (e.ColumnIndex == 2)
            {
                if (e.RowIndex >= 0)
                {
                    if (InvestmentsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "check")
                    {
                        InvestmentsDataGridView.Rows[e.RowIndex].Cells[3].ReadOnly = false;
                    }
                    else
                    {
                        InvestmentsDataGridView.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                        InvestmentsDataGridView.Rows[e.RowIndex].Cells[3].Value = "";
                        InvestmentsDataGridView.Columns[3].ToolTipText = "Select 'check' in the 'Payment Type' to enter a check number.";
                    }
                }
            }
        }

        private void InvestmentsDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[4].Value = Globals.DefaultCreditToType;
            e.Row.Cells[2].Value = Globals.DefaultPaymentType;
            e.Row.Cells[1].Value = Globals.DefaultInvestmentAmount;
            e.Row.Cells[6].Value = "false";
            e.Row.Cells[9].Value = "true";
        }


        private bool checkForInvalidValues(DataGridViewRow row)
        {
            if (row.Cells[1].Value == null) //Amount Column
            {
                MessageBox.Show("A positive non-zero value must be entered for the amount column in row " + row.Index);
                return true;
            }
            int outAmount;
            if (Int32.TryParse(row.Cells[1].Value.ToString(), out outAmount))
            {
                if (outAmount < 1)
                {
                    MessageBox.Show("A positive non-zero value must be entered for the amount column in row " + row.Index);
                    return true;
                }
            }

            if (row.Cells[6].Value == null)
            {
                MessageBox.Show("The value for 'Reinvest' for row " + row.Index + " cannot be null.");
                return true;
            }
            return false;
        }

        private void InvestmentsDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (InvestmentsDataGridView.CurrentCell is DataGridViewComboBoxCell || InvestmentsDataGridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                InvestmentsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                InvestmentsDataGridView.EndEdit();
            }
        }


        private void saveAndEmailCertificatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InvestmentsDataGridView.SelectedRows.Count == 0)
            {
                var result = MessageBox.Show("You have not selected any investments to email.");
                return;
            }

            if(EmailTextBox.Text == "")
            {
                MessageBox.Show("Please provide an email address.");
                return;
            }

            if (!RequiredFieldsAreFilledOut())
            {
                MessageBox.Show("Please fill out all required fields.");
                return;
            }
            if (LabelNameTextBox.Text != FirstNameTextBox.Text + " " + LastNameTextBox.Text)
            {
                var result = MessageBox.Show("The label name does not match the first and last name.  Continue?", "Name Mis-match Alert!", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            //First check for invalid cells on the datagrid
            foreach (DataGridViewRow row in InvestmentsDataGridView.SelectedRows)
            {
                if (checkForInvalidValues(row))
                {
                    return;
                }
            }
            var dialogResult = MessageBox.Show("Changes will be saved now.  Continue?", "Alert!", MessageBoxButtons.YesNo);
            if(dialogResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            string lastInvestYear = LastInvYearTextBox.Text;
            List<Investment2> newInvestments = new List<Investment2>();
            List<Investment2> updatedInvestments = new List<Investment2>();

            FetchNewAndUpdatedInvestments(newInvestments, updatedInvestments, lastInvestYear);

            #region old code that correctly populates the list of new and updated investments from the selected rows
            //foreach (DataGridViewRow row in InvestmentsDataGridView.SelectedRows)
            //{
            //    int outAmount, outYouthID;
            //    string outReinvest;
            //    string checkNumber = "";
            //    if (Int32.TryParse(row.Cells[1].Value.ToString(), out outAmount))
            //    {

            //    }
            //    if (row.Cells[3].Value != null)
            //    {
            //        checkNumber = row.Cells[3].Value.ToString();
            //    }
            //    if (row.Cells[4].Value.ToString() != "youth")
            //    {
            //        outYouthID = -1;
            //    }
            //    else
            //    {
            //        outYouthID = Globals.GlobalYouth.Where(y => y.FullName == row.Cells[5].Value.ToString()).Select(y => y.YouthID).Single();
            //    }
            //    if (row.Cells[6].Value.GetType() == typeof(string))
            //    {
            //        if (row.Cells[6].Value.ToString() == "false")
            //        {
            //            outReinvest = "0";
            //        }
            //        else
            //        {
            //            outReinvest = "1";
            //        }

            //    }
            //    else
            //    {
            //        if ((bool)row.Cells[6].Value == true)
            //        {
            //            outReinvest = "1";
            //        }
            //        else
            //        {
            //            outReinvest = "0";
            //        }
            //    }
            //    if (row.Cells[9].Value.ToString() == "true") //If true it's a bran new investment
            //    {
            //        lastInvestYear = DateTime.Now.Year.ToString(); //Update the investor's LastInvestYear since we're adding a new investment this year
            //        newInvestments.Add(new Investment2(
            //                _investorID: selectedInvestor.InvestorID,
            //                _date: row.Cells[0].Value.ToString(),
            //                _amount: outAmount,
            //                _creditTo: row.Cells[4].Value.ToString(),
            //                _youthID: outYouthID,
            //                _paymentType: row.Cells[2].Value.ToString(),
            //                _checkNumber: checkNumber,
            //                _reinvest: outReinvest
            //            ));
            //    }
            //    else //This is a previously created investment we're now updating
            //    {
            //        int outInvestmentID;
            //        if (Int32.TryParse(row.Cells[8].Value.ToString(), out outInvestmentID)) { }
            //        updatedInvestments.Add(new Investment2(
            //            _investmentID: outInvestmentID,
            //            _investorID: selectedInvestor.InvestorID,
            //            _date: row.Cells[0].Value.ToString(),
            //            _amount: outAmount,
            //            _certificateNumber: row.Cells[7].Value.ToString(),
            //            _creditTo: row.Cells[4].Value.ToString(),
            //            _youthID: outYouthID,
            //            _paymentType: row.Cells[2].Value.ToString(),
            //            _checkNumber: checkNumber,
            //            _reinvest: outReinvest
            //        ));
            //    }
            //}
            #endregion
            //Now update the investor's information in the DB
            if (!DBCommunication.UpdateInvestor(selectedInvestor.InvestorID, FirstNameTextBox.Text, LastNameTextBox.Text, AddressTextBox.Text,
                CityTextBox.Text, StateTextBox.Text, ZipTextBox.Text, EmailTextBox.Text, PhoneMaskedTextBox.Text, InvestorDeceasedCheckBox.Checked,
                JoinDateTimePicker.Value, NotesRichTextBox.Text, LabelNameTextBox.Text, lastInvestYear))
            {
                return;
            }

            //Save the new investments
            int numNewInvestmentsSaved = 0;
            if (newInvestments.Count > 0)
            {
                numNewInvestmentsSaved = DBCommunication.SaveNewInvestments(newInvestments);
                if (numNewInvestmentsSaved == 0)
                {
                    MessageBox.Show("Any updates made to the investor were saved to the database.  New or updated investments were not saved. 0 investments were emailed.");
                    return;
                }
            }

            //Save updates to existing investments
            int numInvestmentsUpdated = 0;
            if (updatedInvestments.Count > 0)
            {
                numInvestmentsUpdated = DBCommunication.UpdateInvestments(updatedInvestments);
                if (numInvestmentsUpdated == 0)
                {
                    MessageBox.Show("Any updates made to the investor were saved to the database.  Any new investments may have been saved to the database but updated investments were not saved. 0 investments were emailed.");
                    return;
                }
            }

            int numEmailedNewInvestments = 0;
            int numEmailedUpdatedInvestements = 0;
            PDFCreator pdfCreator = new PDFCreator(Globals.GlobalInvestors.Where(i=>i.InvestorID == selectedInvestor.InvestorID).Single());
            bool emailSuccess = false;
            bool finalEmailSuccess = true;
            foreach (Investment2 i in updatedInvestments)
            {
                emailSuccess = pdfCreator.createPDF(i, "email");
                if(!emailSuccess)
                {
                    finalEmailSuccess = false;
                }
                numEmailedUpdatedInvestements++;
            }
            foreach (Investment2 i in newInvestments)
            {
                emailSuccess = pdfCreator.createPDF(i, "email");
                if (!emailSuccess)
                {
                    finalEmailSuccess = false ;
                }
                numEmailedNewInvestments++;
            }

            if (finalEmailSuccess)
            {
                if (newInvestments.Count > 0 && updatedInvestments.Count > 0)
                {
                    MessageBox.Show(string.Format("The program has attempted to email {0} new investment(s) and {1} updated investment(s).  Please check your email account to verify.", numEmailedNewInvestments, numEmailedUpdatedInvestements));
                }
                else if (newInvestments.Count > 0)
                {
                    MessageBox.Show(string.Format("The program has attempted to email {0} new investment(s).  Please check your email account to verify.", numEmailedNewInvestments));
                }
                else if (updatedInvestments.Count > 0)
                {
                    MessageBox.Show(string.Format("The program has attempted to email {0} updated investment(s).  Please check your email account to verify", numEmailedUpdatedInvestements));
                }
            }
            Globals.rebindOnMainForm = true;
            this.Close();
        }

        private bool RequiredFieldsAreFilledOut()
        {
            if(
                    FirstNameTextBox.Text == "" ||
                    LastNameTextBox.Text == "" ||
                    AddressTextBox.Text == "" ||
                    CityTextBox.Text == "" ||
                    StateTextBox.Text == "" ||
                    ZipTextBox.Text == "" ||
                    LabelNameTextBox.Text == ""
                )
            {
                return false;
            }
            return true;
        }
        private void FetchNewAndUpdatedInvestments(List<Investment2> newInvestments, List<Investment2> updatedInvestments, string lastInvestYear)
        {
            foreach (DataGridViewRow row in InvestmentsDataGridView.SelectedRows)
            {
                int outAmount, outYouthID;
                string outReinvest;
                string checkNumber = "";
                if (Int32.TryParse(row.Cells[1].Value.ToString(), out outAmount))
                {

                }
                if (row.Cells[3].Value != null)
                {
                    checkNumber = row.Cells[3].Value.ToString();
                }
                if (row.Cells[4].Value.ToString() != "youth")
                {
                    outYouthID = -1;
                }
                else
                {
                    outYouthID = Globals.GlobalYouth.Where(y => y.FullName == row.Cells[5].Value.ToString()).Select(y => y.YouthID).Single();
                }
                if (row.Cells[6].Value.GetType() == typeof(string))
                {
                    if (row.Cells[6].Value.ToString() == "false")
                    {
                        outReinvest = "0";
                    }
                    else
                    {
                        outReinvest = "1";
                    }

                }
                else
                {
                    if ((bool)row.Cells[6].Value == true)
                    {
                        outReinvest = "1";
                    }
                    else
                    {
                        outReinvest = "0";
                    }
                }
                if (row.Cells[9].Value.ToString() == "true") //If true it's a bran new investment
                {
                    lastInvestYear = DateTime.Now.Year.ToString(); //Update the investor's LastInvestYear since we're adding a new investment this year
                    newInvestments.Add(new Investment2(
                            _investorID: selectedInvestor.InvestorID,
                            _date: row.Cells[0].Value.ToString(),
                            _amount: outAmount,
                            _creditTo: row.Cells[4].Value.ToString(),
                            _youthID: outYouthID,
                            _paymentType: row.Cells[2].Value.ToString(),
                            _checkNumber: checkNumber,
                            _reinvest: outReinvest
                        ));
                }
                else //This is a previously created investment we're now updating
                {
                    int outInvestmentID;
                    if (Int32.TryParse(row.Cells[8].Value.ToString(), out outInvestmentID)) { }
                    updatedInvestments.Add(new Investment2(
                        _investmentID: outInvestmentID,
                        _investorID: selectedInvestor.InvestorID,
                        _date: row.Cells[0].Value.ToString(),
                        _amount: outAmount,
                        _certificateNumber: row.Cells[7].Value.ToString(),
                        _creditTo: row.Cells[4].Value.ToString(),
                        _youthID: outYouthID,
                        _paymentType: row.Cells[2].Value.ToString(),
                        _checkNumber: checkNumber,
                        _reinvest: outReinvest
                    ));
                }
            }
        }

        private void InvestorForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}
