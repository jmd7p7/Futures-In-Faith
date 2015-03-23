namespace FuturesInFaith1._4
{
    partial class AddYouthForm
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
            this.AddYouthSubmitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddYouthFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.AddYouthLastNameTextBox = new System.Windows.Forms.TextBox();
            this.AddYouthCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddYouthSubmitButton
            // 
            this.AddYouthSubmitButton.Location = new System.Drawing.Point(78, 105);
            this.AddYouthSubmitButton.Name = "AddYouthSubmitButton";
            this.AddYouthSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.AddYouthSubmitButton.TabIndex = 0;
            this.AddYouthSubmitButton.Text = "Add Youth";
            this.AddYouthSubmitButton.UseVisualStyleBackColor = true;
            this.AddYouthSubmitButton.Click += new System.EventHandler(this.AddYouthSubmitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // AddYouthFirstNameTextBox
            // 
            this.AddYouthFirstNameTextBox.Location = new System.Drawing.Point(78, 29);
            this.AddYouthFirstNameTextBox.Name = "AddYouthFirstNameTextBox";
            this.AddYouthFirstNameTextBox.Size = new System.Drawing.Size(160, 20);
            this.AddYouthFirstNameTextBox.TabIndex = 3;
            // 
            // AddYouthLastNameTextBox
            // 
            this.AddYouthLastNameTextBox.Location = new System.Drawing.Point(78, 70);
            this.AddYouthLastNameTextBox.Name = "AddYouthLastNameTextBox";
            this.AddYouthLastNameTextBox.Size = new System.Drawing.Size(160, 20);
            this.AddYouthLastNameTextBox.TabIndex = 4;
            // 
            // AddYouthCancelButton
            // 
            this.AddYouthCancelButton.Location = new System.Drawing.Point(163, 105);
            this.AddYouthCancelButton.Name = "AddYouthCancelButton";
            this.AddYouthCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AddYouthCancelButton.TabIndex = 5;
            this.AddYouthCancelButton.Text = "Cancel";
            this.AddYouthCancelButton.UseVisualStyleBackColor = true;
            this.AddYouthCancelButton.Click += new System.EventHandler(this.AddYouthCancelButton_Click);
            // 
            // AddYouthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 149);
            this.Controls.Add(this.AddYouthCancelButton);
            this.Controls.Add(this.AddYouthLastNameTextBox);
            this.Controls.Add(this.AddYouthFirstNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddYouthSubmitButton);
            this.MaximumSize = new System.Drawing.Size(278, 188);
            this.MinimumSize = new System.Drawing.Size(278, 188);
            this.Name = "AddYouthForm";
            this.Text = "Add Youth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddYouthSubmitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AddYouthFirstNameTextBox;
        private System.Windows.Forms.TextBox AddYouthLastNameTextBox;
        private System.Windows.Forms.Button AddYouthCancelButton;
    }
}