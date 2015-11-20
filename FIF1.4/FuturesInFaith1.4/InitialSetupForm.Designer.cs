namespace FuturesInFaith1._4
{
    partial class InitialSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialSetupForm));
            this.CreateSettingsButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.DefaultFilePathTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.DefaultCreditToComboBox = new System.Windows.Forms.ComboBox();
            this.DefaultPaymentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.DefaultAmountComboBox = new System.Windows.Forms.ComboBox();
            this.ProgramEndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ProgramStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AdminPasswordTextBox = new System.Windows.Forms.TextBox();
            this.AdminEmailTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateSettingsButton
            // 
            this.CreateSettingsButton.Location = new System.Drawing.Point(152, 303);
            this.CreateSettingsButton.Name = "CreateSettingsButton";
            this.CreateSettingsButton.Size = new System.Drawing.Size(188, 23);
            this.CreateSettingsButton.TabIndex = 35;
            this.CreateSettingsButton.Text = "Create Settings";
            this.CreateSettingsButton.UseVisualStyleBackColor = true;
            this.CreateSettingsButton.Click += new System.EventHandler(this.CreateSettingsButton_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(148, 262);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "*Double click to select folder";
            // 
            // DefaultFilePathTextBox
            // 
            this.DefaultFilePathTextBox.Location = new System.Drawing.Point(151, 239);
            this.DefaultFilePathTextBox.Name = "DefaultFilePathTextBox";
            this.DefaultFilePathTextBox.ReadOnly = true;
            this.DefaultFilePathTextBox.Size = new System.Drawing.Size(188, 20);
            this.DefaultFilePathTextBox.TabIndex = 33;
            this.DefaultFilePathTextBox.DoubleClick += new System.EventHandler(this.DefaultFilePathTextBox_DoubleClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 242);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Folder for saving PDFs:";
            // 
            // DefaultCreditToComboBox
            // 
            this.DefaultCreditToComboBox.FormattingEnabled = true;
            this.DefaultCreditToComboBox.Items.AddRange(new object[] {
            "general fund",
            "youth",
            "N/A"});
            this.DefaultCreditToComboBox.Location = new System.Drawing.Point(152, 204);
            this.DefaultCreditToComboBox.Name = "DefaultCreditToComboBox";
            this.DefaultCreditToComboBox.Size = new System.Drawing.Size(121, 21);
            this.DefaultCreditToComboBox.TabIndex = 31;
            this.DefaultCreditToComboBox.Text = "general fund";
            // 
            // DefaultPaymentTypeComboBox
            // 
            this.DefaultPaymentTypeComboBox.FormattingEnabled = true;
            this.DefaultPaymentTypeComboBox.Items.AddRange(new object[] {
            "cash",
            "check",
            "N/A"});
            this.DefaultPaymentTypeComboBox.Location = new System.Drawing.Point(152, 172);
            this.DefaultPaymentTypeComboBox.Name = "DefaultPaymentTypeComboBox";
            this.DefaultPaymentTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.DefaultPaymentTypeComboBox.TabIndex = 30;
            this.DefaultPaymentTypeComboBox.Text = "check";
            // 
            // DefaultAmountComboBox
            // 
            this.DefaultAmountComboBox.FormattingEnabled = true;
            this.DefaultAmountComboBox.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100",
            "105",
            "110",
            "115",
            "120",
            "125",
            "130",
            "135",
            "140",
            "145",
            "150",
            "155",
            "160",
            "165",
            "170",
            "175",
            "180",
            "185",
            "190",
            "195",
            "200"});
            this.DefaultAmountComboBox.Location = new System.Drawing.Point(151, 140);
            this.DefaultAmountComboBox.Name = "DefaultAmountComboBox";
            this.DefaultAmountComboBox.Size = new System.Drawing.Size(121, 21);
            this.DefaultAmountComboBox.TabIndex = 29;
            this.DefaultAmountComboBox.Text = "40";
            // 
            // ProgramEndDateTimePicker
            // 
            this.ProgramEndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ProgramEndDateTimePicker.Location = new System.Drawing.Point(151, 105);
            this.ProgramEndDateTimePicker.Name = "ProgramEndDateTimePicker";
            this.ProgramEndDateTimePicker.Size = new System.Drawing.Size(188, 20);
            this.ProgramEndDateTimePicker.TabIndex = 28;
            this.ProgramEndDateTimePicker.Value = new System.DateTime(2016, 1, 29, 0, 0, 0, 0);
            // 
            // ProgramStartDateTimePicker
            // 
            this.ProgramStartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ProgramStartDateTimePicker.Location = new System.Drawing.Point(151, 73);
            this.ProgramStartDateTimePicker.Name = "ProgramStartDateTimePicker";
            this.ProgramStartDateTimePicker.Size = new System.Drawing.Size(188, 20);
            this.ProgramStartDateTimePicker.TabIndex = 27;
            this.ProgramStartDateTimePicker.Value = new System.DateTime(2015, 5, 1, 0, 0, 0, 0);
            // 
            // AdminPasswordTextBox
            // 
            this.AdminPasswordTextBox.Location = new System.Drawing.Point(151, 44);
            this.AdminPasswordTextBox.Name = "AdminPasswordTextBox";
            this.AdminPasswordTextBox.Size = new System.Drawing.Size(188, 20);
            this.AdminPasswordTextBox.TabIndex = 26;
            this.AdminPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // AdminEmailTextBox
            // 
            this.AdminEmailTextBox.Location = new System.Drawing.Point(151, 12);
            this.AdminEmailTextBox.Name = "AdminEmailTextBox";
            this.AdminEmailTextBox.Size = new System.Drawing.Size(188, 20);
            this.AdminEmailTextBox.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 207);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Default Credit To:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Default Payment Type:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Default Investment Amount:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Program End Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Program Start Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Admin Email Password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Admin Email:";
            // 
            // InitialSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 338);
            this.Controls.Add(this.CreateSettingsButton);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.DefaultFilePathTextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.DefaultCreditToComboBox);
            this.Controls.Add(this.DefaultPaymentTypeComboBox);
            this.Controls.Add(this.DefaultAmountComboBox);
            this.Controls.Add(this.ProgramEndDateTimePicker);
            this.Controls.Add(this.ProgramStartDateTimePicker);
            this.Controls.Add(this.AdminPasswordTextBox);
            this.Controls.Add(this.AdminEmailTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InitialSetupForm";
            this.Text = "InitialSetupForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InitialSetupForm_FormClosing);
            this.Load += new System.EventHandler(this.InitialSetupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateSettingsButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox DefaultFilePathTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox DefaultCreditToComboBox;
        private System.Windows.Forms.ComboBox DefaultPaymentTypeComboBox;
        private System.Windows.Forms.ComboBox DefaultAmountComboBox;
        private System.Windows.Forms.DateTimePicker ProgramEndDateTimePicker;
        private System.Windows.Forms.DateTimePicker ProgramStartDateTimePicker;
        private System.Windows.Forms.TextBox AdminPasswordTextBox;
        private System.Windows.Forms.TextBox AdminEmailTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}