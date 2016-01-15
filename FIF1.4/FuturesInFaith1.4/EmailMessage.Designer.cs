namespace FuturesInFaith1._4
{
    partial class EmailMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailMessage));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EmailSubjectTextbox = new System.Windows.Forms.TextBox();
            this.EmailMessageRichText = new System.Windows.Forms.RichTextBox();
            this.EmailVariablesListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveAndCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MessageBodyRadio = new System.Windows.Forms.RadioButton();
            this.EmailSubjectRadio = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Message Body:";
            // 
            // EmailSubjectTextbox
            // 
            this.EmailSubjectTextbox.Location = new System.Drawing.Point(12, 50);
            this.EmailSubjectTextbox.Name = "EmailSubjectTextbox";
            this.EmailSubjectTextbox.Size = new System.Drawing.Size(327, 20);
            this.EmailSubjectTextbox.TabIndex = 2;
            // 
            // EmailMessageRichText
            // 
            this.EmailMessageRichText.Location = new System.Drawing.Point(12, 96);
            this.EmailMessageRichText.Name = "EmailMessageRichText";
            this.EmailMessageRichText.Size = new System.Drawing.Size(326, 303);
            this.EmailMessageRichText.TabIndex = 3;
            this.EmailMessageRichText.Text = "";
            // 
            // EmailVariablesListBox
            // 
            FIFLibrary.EmailMessage.EmailVariablesManager variablesManager =
                new FIFLibrary.EmailMessage.EmailVariablesManager();
            this.EmailVariablesListBox.DataSource = variablesManager.getVariableNames();
            this.EmailVariablesListBox.FormattingEnabled = true;
            this.EmailVariablesListBox.Location = new System.Drawing.Point(368, 174);
            this.EmailVariablesListBox.Name = "EmailVariablesListBox";
            this.EmailVariablesListBox.Size = new System.Drawing.Size(182, 225);
            this.EmailVariablesListBox.TabIndex = 4;
            this.EmailVariablesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EmailVariablesListBox_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Variables:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAndCloseToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(564, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveAndCloseToolStripMenuItem
            // 
            this.saveAndCloseToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.saveAndCloseToolStripMenuItem.Name = "saveAndCloseToolStripMenuItem";
            this.saveAndCloseToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.saveAndCloseToolStripMenuItem.Text = "Save and Close";
            this.saveAndCloseToolStripMenuItem.Click += new System.EventHandler(this.saveAndCloseToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.cancelToolStripMenuItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MessageBodyRadio);
            this.groupBox1.Controls.Add(this.EmailSubjectRadio);
            this.groupBox1.Location = new System.Drawing.Point(368, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 77);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // MessageBodyRadio
            // 
            this.MessageBodyRadio.AutoSize = true;
            this.MessageBodyRadio.Location = new System.Drawing.Point(6, 42);
            this.MessageBodyRadio.Name = "MessageBodyRadio";
            this.MessageBodyRadio.Size = new System.Drawing.Size(126, 17);
            this.MessageBodyRadio.TabIndex = 1;
            this.MessageBodyRadio.Text = "Use in message body";
            this.MessageBodyRadio.UseVisualStyleBackColor = true;
            this.MessageBodyRadio.CheckedChanged += new System.EventHandler(this.MessageBodyRadio_CheckedChanged);
            // 
            // EmailSubjectRadio
            // 
            this.EmailSubjectRadio.AutoSize = true;
            this.EmailSubjectRadio.Checked = true;
            this.EmailSubjectRadio.Location = new System.Drawing.Point(6, 19);
            this.EmailSubjectRadio.Name = "EmailSubjectRadio";
            this.EmailSubjectRadio.Size = new System.Drawing.Size(92, 17);
            this.EmailSubjectRadio.TabIndex = 0;
            this.EmailSubjectRadio.TabStop = true;
            this.EmailSubjectRadio.Text = "Use in subject";
            this.EmailSubjectRadio.UseVisualStyleBackColor = true;
            this.EmailSubjectRadio.CheckedChanged += new System.EventHandler(this.EmailSubjectRadio_CheckedChanged);
            // 
            // EmailMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 410);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EmailVariablesListBox);
            this.Controls.Add(this.EmailMessageRichText);
            this.Controls.Add(this.EmailSubjectTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EmailMessage";
            this.Text = "EmailMessage";
            this.Load += new System.EventHandler(this.EmailMessage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EmailSubjectTextbox;
        private System.Windows.Forms.RichTextBox EmailMessageRichText;
        private System.Windows.Forms.ListBox EmailVariablesListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveAndCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton MessageBodyRadio;
        private System.Windows.Forms.RadioButton EmailSubjectRadio;
    }
}