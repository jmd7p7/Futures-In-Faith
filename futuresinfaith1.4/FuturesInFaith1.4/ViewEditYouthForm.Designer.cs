namespace FuturesInFaith1._4
{
    partial class ViewEditYouthForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.EditYouthFirstNameLabel = new System.Windows.Forms.Label();
            this.EditYouthLastNameLabel = new System.Windows.Forms.Label();
            this.EditYouthFullNameLabel = new System.Windows.Forms.Label();
            this.EditYouthIsActiveLabel = new System.Windows.Forms.Label();
            this.EditYouthFullNameTextBox = new System.Windows.Forms.TextBox();
            this.EditYouthLastNameTextBox = new System.Windows.Forms.TextBox();
            this.EditYouthFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.EditYouthIsActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditYouthFirstNameLabel
            // 
            this.EditYouthFirstNameLabel.AutoSize = true;
            this.EditYouthFirstNameLabel.Location = new System.Drawing.Point(14, 20);
            this.EditYouthFirstNameLabel.Name = "EditYouthFirstNameLabel";
            this.EditYouthFirstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.EditYouthFirstNameLabel.TabIndex = 2;
            this.EditYouthFirstNameLabel.Text = "First Name:";
            // 
            // EditYouthLastNameLabel
            // 
            this.EditYouthLastNameLabel.AutoSize = true;
            this.EditYouthLastNameLabel.Location = new System.Drawing.Point(12, 54);
            this.EditYouthLastNameLabel.Name = "EditYouthLastNameLabel";
            this.EditYouthLastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.EditYouthLastNameLabel.TabIndex = 3;
            this.EditYouthLastNameLabel.Text = "Last Name:";
            // 
            // EditYouthFullNameLabel
            // 
            this.EditYouthFullNameLabel.AutoSize = true;
            this.EditYouthFullNameLabel.Location = new System.Drawing.Point(16, 88);
            this.EditYouthFullNameLabel.Name = "EditYouthFullNameLabel";
            this.EditYouthFullNameLabel.Size = new System.Drawing.Size(57, 13);
            this.EditYouthFullNameLabel.TabIndex = 4;
            this.EditYouthFullNameLabel.Text = "Full Name:";
            // 
            // EditYouthIsActiveLabel
            // 
            this.EditYouthIsActiveLabel.AutoSize = true;
            this.EditYouthIsActiveLabel.Location = new System.Drawing.Point(22, 119);
            this.EditYouthIsActiveLabel.Name = "EditYouthIsActiveLabel";
            this.EditYouthIsActiveLabel.Size = new System.Drawing.Size(51, 13);
            this.EditYouthIsActiveLabel.TabIndex = 5;
            this.EditYouthIsActiveLabel.Text = "Is Active:";
            // 
            // EditYouthFullNameTextBox
            // 
            this.EditYouthFullNameTextBox.Location = new System.Drawing.Point(80, 85);
            this.EditYouthFullNameTextBox.Name = "EditYouthFullNameTextBox";
            this.EditYouthFullNameTextBox.Size = new System.Drawing.Size(155, 20);
            this.EditYouthFullNameTextBox.TabIndex = 6;
            // 
            // EditYouthLastNameTextBox
            // 
            this.EditYouthLastNameTextBox.Location = new System.Drawing.Point(79, 51);
            this.EditYouthLastNameTextBox.Name = "EditYouthLastNameTextBox";
            this.EditYouthLastNameTextBox.Size = new System.Drawing.Size(155, 20);
            this.EditYouthLastNameTextBox.TabIndex = 7;
            // 
            // EditYouthFirstNameTextBox
            // 
            this.EditYouthFirstNameTextBox.Location = new System.Drawing.Point(80, 17);
            this.EditYouthFirstNameTextBox.Name = "EditYouthFirstNameTextBox";
            this.EditYouthFirstNameTextBox.Size = new System.Drawing.Size(155, 20);
            this.EditYouthFirstNameTextBox.TabIndex = 8;
            // 
            // EditYouthIsActiveCheckBox
            // 
            this.EditYouthIsActiveCheckBox.AutoSize = true;
            this.EditYouthIsActiveCheckBox.Location = new System.Drawing.Point(79, 119);
            this.EditYouthIsActiveCheckBox.Name = "EditYouthIsActiveCheckBox";
            this.EditYouthIsActiveCheckBox.Size = new System.Drawing.Size(15, 14);
            this.EditYouthIsActiveCheckBox.TabIndex = 9;
            this.EditYouthIsActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // ViewEditYouthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 185);
            this.Controls.Add(this.EditYouthIsActiveCheckBox);
            this.Controls.Add(this.EditYouthFirstNameTextBox);
            this.Controls.Add(this.EditYouthLastNameTextBox);
            this.Controls.Add(this.EditYouthFullNameTextBox);
            this.Controls.Add(this.EditYouthIsActiveLabel);
            this.Controls.Add(this.EditYouthFullNameLabel);
            this.Controls.Add(this.EditYouthLastNameLabel);
            this.Controls.Add(this.EditYouthFirstNameLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(270, 224);
            this.MinimumSize = new System.Drawing.Size(270, 224);
            this.Name = "ViewEditYouthForm";
            this.Text = "View/Edit Youth";
            this.Load += new System.EventHandler(this.ViewEditYouthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label EditYouthFirstNameLabel;
        private System.Windows.Forms.Label EditYouthLastNameLabel;
        private System.Windows.Forms.Label EditYouthFullNameLabel;
        private System.Windows.Forms.Label EditYouthIsActiveLabel;
        private System.Windows.Forms.TextBox EditYouthFullNameTextBox;
        private System.Windows.Forms.TextBox EditYouthLastNameTextBox;
        private System.Windows.Forms.TextBox EditYouthFirstNameTextBox;
        private System.Windows.Forms.CheckBox EditYouthIsActiveCheckBox;
    }
}