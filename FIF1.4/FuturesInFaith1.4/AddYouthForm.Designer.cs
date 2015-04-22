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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddYouthFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.AddYouthLastNameTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveNewYouthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // AddYouthFirstNameTextBox
            // 
            this.AddYouthFirstNameTextBox.Location = new System.Drawing.Point(78, 39);
            this.AddYouthFirstNameTextBox.Name = "AddYouthFirstNameTextBox";
            this.AddYouthFirstNameTextBox.Size = new System.Drawing.Size(246, 20);
            this.AddYouthFirstNameTextBox.TabIndex = 0;
            // 
            // AddYouthLastNameTextBox
            // 
            this.AddYouthLastNameTextBox.Location = new System.Drawing.Point(78, 80);
            this.AddYouthLastNameTextBox.Name = "AddYouthLastNameTextBox";
            this.AddYouthLastNameTextBox.Size = new System.Drawing.Size(246, 20);
            this.AddYouthLastNameTextBox.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveNewYouthToolStripMenuItem,
            this.saveCloseToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(331, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveNewYouthToolStripMenuItem
            // 
            this.saveNewYouthToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.saveNewYouthToolStripMenuItem.Name = "saveNewYouthToolStripMenuItem";
            this.saveNewYouthToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.saveNewYouthToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.saveNewYouthToolStripMenuItem.Text = "Save && New Youth";
            this.saveNewYouthToolStripMenuItem.Click += new System.EventHandler(this.saveNewYouthToolStripMenuItem_Click);
            // 
            // saveCloseToolStripMenuItem
            // 
            this.saveCloseToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.saveCloseToolStripMenuItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.saveCloseToolStripMenuItem.Name = "saveCloseToolStripMenuItem";
            this.saveCloseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveCloseToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.saveCloseToolStripMenuItem.Text = "Save && Close";
            this.saveCloseToolStripMenuItem.Click += new System.EventHandler(this.saveCloseToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // AddYouthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 116);
            this.Controls.Add(this.AddYouthLastNameTextBox);
            this.Controls.Add(this.AddYouthFirstNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(400, 155);
            this.MinimumSize = new System.Drawing.Size(278, 155);
            this.Name = "AddYouthForm";
            this.Text = "Add Youth";
            this.Activated += new System.EventHandler(this.AddYouthForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddYouthForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddYouthForm_FormClosed);
            this.Load += new System.EventHandler(this.AddYouthForm_Load);
            this.Shown += new System.EventHandler(this.AddYouthForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AddYouthFirstNameTextBox;
        private System.Windows.Forms.TextBox AddYouthLastNameTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveNewYouthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
    }
}