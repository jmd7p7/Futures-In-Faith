namespace FuturesInFaith1._4
{
    partial class MainForm
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.InvestorsTab = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.ViewEditInvestorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InvestorsListBox = new System.Windows.Forms.ListBox();
            this.Youth = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.YouthListBox = new System.Windows.Forms.ListBox();
            this.MainTabControl.SuspendLayout();
            this.InvestorsTab.SuspendLayout();
            this.Youth.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.InvestorsTab);
            this.MainTabControl.Controls.Add(this.Youth);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(354, 361);
            this.MainTabControl.TabIndex = 0;
            // 
            // InvestorsTab
            // 
            this.InvestorsTab.Controls.Add(this.button2);
            this.InvestorsTab.Controls.Add(this.ViewEditInvestorButton);
            this.InvestorsTab.Controls.Add(this.label1);
            this.InvestorsTab.Controls.Add(this.InvestorsListBox);
            this.InvestorsTab.Location = new System.Drawing.Point(4, 22);
            this.InvestorsTab.Name = "InvestorsTab";
            this.InvestorsTab.Padding = new System.Windows.Forms.Padding(3);
            this.InvestorsTab.Size = new System.Drawing.Size(346, 335);
            this.InvestorsTab.TabIndex = 0;
            this.InvestorsTab.Text = "Investors";
            this.InvestorsTab.UseVisualStyleBackColor = true;
            this.InvestorsTab.Enter += new System.EventHandler(this.InvestorsTab_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Add Investor";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ViewEditInvestorButton
            // 
            this.ViewEditInvestorButton.Location = new System.Drawing.Point(188, 115);
            this.ViewEditInvestorButton.Name = "ViewEditInvestorButton";
            this.ViewEditInvestorButton.Size = new System.Drawing.Size(146, 23);
            this.ViewEditInvestorButton.TabIndex = 2;
            this.ViewEditInvestorButton.Text = "View/Edit Investor";
            this.ViewEditInvestorButton.UseVisualStyleBackColor = true;
            this.ViewEditInvestorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Investors";
            // 
            // InvestorsListBox
            // 
            this.InvestorsListBox.FormattingEnabled = true;
            this.InvestorsListBox.Location = new System.Drawing.Point(8, 23);
            this.InvestorsListBox.Name = "InvestorsListBox";
            this.InvestorsListBox.Size = new System.Drawing.Size(174, 303);
            this.InvestorsListBox.TabIndex = 0;
            this.InvestorsListBox.SelectedIndexChanged += new System.EventHandler(this.InvestorsListBox_SelectedIndexChanged);
            // 
            // Youth
            // 
            this.Youth.Controls.Add(this.button1);
            this.Youth.Controls.Add(this.button3);
            this.Youth.Controls.Add(this.label2);
            this.Youth.Controls.Add(this.YouthListBox);
            this.Youth.Location = new System.Drawing.Point(4, 22);
            this.Youth.Name = "Youth";
            this.Youth.Padding = new System.Windows.Forms.Padding(3);
            this.Youth.Size = new System.Drawing.Size(346, 335);
            this.Youth.TabIndex = 1;
            this.Youth.Text = "Youth";
            this.Youth.UseVisualStyleBackColor = true;
            this.Youth.Enter += new System.EventHandler(this.Youth_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add Youth";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(190, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "View/Edit Youth";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Youth";
            // 
            // YouthListBox
            // 
            this.YouthListBox.FormattingEnabled = true;
            this.YouthListBox.Location = new System.Drawing.Point(10, 24);
            this.YouthListBox.Name = "YouthListBox";
            this.YouthListBox.Size = new System.Drawing.Size(174, 303);
            this.YouthListBox.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 361);
            this.Controls.Add(this.MainTabControl);
            this.MaximumSize = new System.Drawing.Size(370, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(370, 400);
            this.Name = "MainForm";
            this.Text = "Futures In Faith";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Enter += new System.EventHandler(this.MainForm_Enter);
            this.MainTabControl.ResumeLayout(false);
            this.InvestorsTab.ResumeLayout(false);
            this.InvestorsTab.PerformLayout();
            this.Youth.ResumeLayout(false);
            this.Youth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage InvestorsTab;
        private System.Windows.Forms.TabPage Youth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox InvestorsListBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ViewEditInvestorButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox YouthListBox;
    }
}

