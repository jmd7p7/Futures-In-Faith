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
using Common.MessageBuilder;

namespace FuturesInFaith1._4
{
    public partial class EmailMessage : Form
    {
        public EmailMessage()
        {
            InitializeComponent();
            EmailVariablesListBox.Focus();
        }

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FIFLibrary.EmailMessage.EmailTemplateCreator emailMessageTemplate =
                    new FIFLibrary.EmailMessage.EmailTemplateCreator(EmailSubjectTextbox.Text, EmailMessageRichText.Text);
                emailMessageTemplate.save();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.Close();
            MessageBox.Show("Your email message has been updated.");
        }

        private void EmailVariablesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MessageBodyRadio.Checked)
            {
                EmailMessageRichText.Text += "{{" + EmailVariablesListBox.SelectedItem + "}}";
                EmailMessageRichTextSetFocus();
            }
            else
            {
                EmailSubjectTextbox.Text += "{{" + EmailVariablesListBox.SelectedItem + "}}";
                EmailSubjectTextBoxSetFocus();
            }
        }

        private void EmailSubjectTextBoxSetFocus()
        {
            EmailSubjectTextbox.Focus();
            EmailSubjectTextbox.SelectionStart = EmailMessageRichText.Text.Length;
        }

        private void EmailMessageRichTextSetFocus()
        {
            EmailMessageRichText.Focus();
            EmailMessageRichText.SelectionStart = EmailMessageRichText.Text.Length;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmailMessage_Load(object sender, EventArgs e)
        {
            EmailMessageRichText.Text = DBCommunication.getEmailMessage();
            EmailSubjectTextbox.Text = DBCommunication.getEmailSubject();
        }


        private void EmailSubjectRadio_CheckedChanged(object sender, EventArgs e)
        {
            EmailSubjectTextBoxSetFocus();
        }

        private void MessageBodyRadio_CheckedChanged(object sender, EventArgs e)
        {
            EmailMessageRichTextSetFocus();
        }
    }
}
