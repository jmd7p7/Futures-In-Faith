namespace FuturesInFaith1._4
{
    partial class AddInvestorForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.savePrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAndEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAndCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InvestorLNTextBox = new System.Windows.Forms.TextBox();
            this.InvestorFNTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.InvestorZipTextBox = new System.Windows.Forms.TextBox();
            this.InvestorStateTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.InvestorCityTextBox = new System.Windows.Forms.TextBox();
            this.InvestorAddressTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.InvestorPhoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.InvestorEmailTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AddInvLastInvYearTextBox = new System.Windows.Forms.TextBox();
            this.InvestorDeceasedCheckBox = new System.Windows.Forms.CheckBox();
            this.InvestorJoinDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.InvestorNotesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.investment2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.investmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InvDataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investment2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePrintToolStripMenuItem,
            this.saveAndEmailToolStripMenuItem,
            this.saveAndCloseToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // savePrintToolStripMenuItem
            // 
            this.savePrintToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.savePrintToolStripMenuItem.Name = "savePrintToolStripMenuItem";
            this.savePrintToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.savePrintToolStripMenuItem.Text = "Save and Print Certificate(s)";
            // 
            // saveAndEmailToolStripMenuItem
            // 
            this.saveAndEmailToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.saveAndEmailToolStripMenuItem.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.saveAndEmailToolStripMenuItem.Name = "saveAndEmailToolStripMenuItem";
            this.saveAndEmailToolStripMenuItem.Size = new System.Drawing.Size(168, 20);
            this.saveAndEmailToolStripMenuItem.Text = "Save and Email Certificate(s)";
            // 
            // saveAndCloseToolStripMenuItem
            // 
            this.saveAndCloseToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.saveAndCloseToolStripMenuItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.saveAndCloseToolStripMenuItem.Name = "saveAndCloseToolStripMenuItem";
            this.saveAndCloseToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.saveAndCloseToolStripMenuItem.Text = "Save and Close";
            this.saveAndCloseToolStripMenuItem.Click += new System.EventHandler(this.saveAndCloseToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InvestorLNTextBox);
            this.groupBox1.Controls.Add(this.InvestorFNTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // InvestorLNTextBox
            // 
            this.InvestorLNTextBox.Location = new System.Drawing.Point(70, 47);
            this.InvestorLNTextBox.Name = "InvestorLNTextBox";
            this.InvestorLNTextBox.Size = new System.Drawing.Size(173, 20);
            this.InvestorLNTextBox.TabIndex = 3;
            // 
            // InvestorFNTextBox
            // 
            this.InvestorFNTextBox.Location = new System.Drawing.Point(71, 20);
            this.InvestorFNTextBox.Name = "InvestorFNTextBox";
            this.InvestorFNTextBox.Size = new System.Drawing.Size(172, 20);
            this.InvestorFNTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.InvestorZipTextBox);
            this.groupBox2.Controls.Add(this.InvestorStateTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.InvestorCityTextBox);
            this.groupBox2.Controls.Add(this.InvestorAddressTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 139);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // InvestorZipTextBox
            // 
            this.InvestorZipTextBox.Location = new System.Drawing.Point(70, 102);
            this.InvestorZipTextBox.MaxLength = 5;
            this.InvestorZipTextBox.Name = "InvestorZipTextBox";
            this.InvestorZipTextBox.Size = new System.Drawing.Size(173, 20);
            this.InvestorZipTextBox.TabIndex = 7;
            this.InvestorZipTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InvestorZipTextBox_KeyPress);
            // 
            // InvestorStateTextBox
            // 
            this.InvestorStateTextBox.Location = new System.Drawing.Point(71, 75);
            this.InvestorStateTextBox.MaxLength = 2;
            this.InvestorStateTextBox.Name = "InvestorStateTextBox";
            this.InvestorStateTextBox.Size = new System.Drawing.Size(173, 20);
            this.InvestorStateTextBox.TabIndex = 6;
            this.InvestorStateTextBox.TextChanged += new System.EventHandler(this.InvestorStateTextBox_TextChanged);
            this.InvestorStateTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InvestorStateTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Zip";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "State";
            // 
            // InvestorCityTextBox
            // 
            this.InvestorCityTextBox.Location = new System.Drawing.Point(70, 47);
            this.InvestorCityTextBox.Name = "InvestorCityTextBox";
            this.InvestorCityTextBox.Size = new System.Drawing.Size(173, 20);
            this.InvestorCityTextBox.TabIndex = 3;
            // 
            // InvestorAddressTextBox
            // 
            this.InvestorAddressTextBox.Location = new System.Drawing.Point(71, 20);
            this.InvestorAddressTextBox.Name = "InvestorAddressTextBox";
            this.InvestorAddressTextBox.Size = new System.Drawing.Size(173, 20);
            this.InvestorAddressTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "City";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Address";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.InvestorPhoneMaskedTextBox);
            this.groupBox3.Controls.Add(this.InvestorEmailTextBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(267, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 83);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // InvestorPhoneMaskedTextBox
            // 
            this.InvestorPhoneMaskedTextBox.Location = new System.Drawing.Point(71, 47);
            this.InvestorPhoneMaskedTextBox.Mask = "(999) 000-0000";
            this.InvestorPhoneMaskedTextBox.Name = "InvestorPhoneMaskedTextBox";
            this.InvestorPhoneMaskedTextBox.Size = new System.Drawing.Size(249, 20);
            this.InvestorPhoneMaskedTextBox.TabIndex = 3;
            // 
            // InvestorEmailTextBox
            // 
            this.InvestorEmailTextBox.Location = new System.Drawing.Point(71, 20);
            this.InvestorEmailTextBox.Name = "InvestorEmailTextBox";
            this.InvestorEmailTextBox.Size = new System.Drawing.Size(249, 20);
            this.InvestorEmailTextBox.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Phone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Email";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AddInvLastInvYearTextBox);
            this.groupBox4.Controls.Add(this.InvestorDeceasedCheckBox);
            this.groupBox4.Controls.Add(this.InvestorJoinDateDateTimePicker);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(267, 111);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 139);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // AddInvLastInvYearTextBox
            // 
            this.AddInvLastInvYearTextBox.Location = new System.Drawing.Point(120, 75);
            this.AddInvLastInvYearTextBox.MaxLength = 4;
            this.AddInvLastInvYearTextBox.Name = "AddInvLastInvYearTextBox";
            this.AddInvLastInvYearTextBox.ReadOnly = true;
            this.AddInvLastInvYearTextBox.Size = new System.Drawing.Size(200, 20);
            this.AddInvLastInvYearTextBox.TabIndex = 4;
            // 
            // InvestorDeceasedCheckBox
            // 
            this.InvestorDeceasedCheckBox.AutoSize = true;
            this.InvestorDeceasedCheckBox.Location = new System.Drawing.Point(120, 50);
            this.InvestorDeceasedCheckBox.Name = "InvestorDeceasedCheckBox";
            this.InvestorDeceasedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.InvestorDeceasedCheckBox.TabIndex = 7;
            this.InvestorDeceasedCheckBox.UseVisualStyleBackColor = true;
            // 
            // InvestorJoinDateDateTimePicker
            // 
            this.InvestorJoinDateDateTimePicker.Location = new System.Drawing.Point(120, 20);
            this.InvestorJoinDateDateTimePicker.Name = "InvestorJoinDateDateTimePicker";
            this.InvestorJoinDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.InvestorJoinDateDateTimePicker.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Last Investment Year";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Deceased";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Join Date";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.InvestorNotesRichTextBox);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(614, 23);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 227);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            // 
            // InvestorNotesRichTextBox
            // 
            this.InvestorNotesRichTextBox.Location = new System.Drawing.Point(7, 35);
            this.InvestorNotesRichTextBox.Name = "InvestorNotesRichTextBox";
            this.InvestorNotesRichTextBox.Size = new System.Drawing.Size(241, 186);
            this.InvestorNotesRichTextBox.TabIndex = 6;
            this.InvestorNotesRichTextBox.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Notes";
            // 
            // investment2BindingSource
            // 
            this.investment2BindingSource.DataSource = typeof(FIFLibrary.Investment2);
            // 
            // investmentBindingSource
            // 
            this.investmentBindingSource.DataSource = typeof(FIFLibrary.Investment);
            // 
            // InvDataGridView
            // 
            this.InvDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvDataGridView.Location = new System.Drawing.Point(12, 258);
            this.InvDataGridView.Name = "InvDataGridView";
            this.InvDataGridView.Size = new System.Drawing.Size(857, 150);
            this.InvDataGridView.TabIndex = 10;
            this.InvDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.InvDataGridView_CellValueChanged);
            this.InvDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.InvDataGridView_CurrentCellDirtyStateChanged);
            this.InvDataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.InvDataGridView_DefaultValuesNeeded);
            this.InvDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.InvDataGridView_EditingControlShowing);
            // 
            // AddInvestorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 415);
            this.Controls.Add(this.InvDataGridView);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AddInvestorForm";
            this.Text = "Add Investor";
            this.Load += new System.EventHandler(this.AddInvestorForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investment2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox InvestorLNTextBox;
        private System.Windows.Forms.TextBox InvestorFNTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox InvestorZipTextBox;
        private System.Windows.Forms.TextBox InvestorStateTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox InvestorCityTextBox;
        private System.Windows.Forms.TextBox InvestorAddressTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MaskedTextBox InvestorPhoneMaskedTextBox;
        private System.Windows.Forms.TextBox InvestorEmailTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox InvestorDeceasedCheckBox;
        private System.Windows.Forms.DateTimePicker InvestorJoinDateDateTimePicker;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox InvestorNotesRichTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox AddInvLastInvYearTextBox;
        private System.Windows.Forms.ToolStripMenuItem savePrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAndEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAndCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.BindingSource investmentBindingSource;
        private System.Windows.Forms.BindingSource investment2BindingSource;
        private System.Windows.Forms.DataGridView InvDataGridView;
    }
}