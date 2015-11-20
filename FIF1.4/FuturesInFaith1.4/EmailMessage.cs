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

namespace FuturesInFaith1._4
{
    public partial class EmailMessage : Form
    {
        public EmailMessage()
        {
            InitializeComponent();
        }

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailMessageBuilder MessageBuilder = 
                new EmailMessageBuilder(EmailSubjectTextbox.Text, EmailMessageRichText.Text);
            if (!MessageBuilder.CreateEmailBody())
                return;
            if (!MessageBuilder.CreateEmailSubject())
                return;
            MessageBox.Show("Your email message has been updated.");
            this.Close();
        }

        private void EmailVariablesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EmailMessageRichText.Text += EmailVariablesListBox.SelectedItem;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmailMessage_Load(object sender, EventArgs e)
        {
            EmailMessageRichText.Text = ReconstructMessage(Globals.EmailMessage, Globals.EmailMessageVariables);
            EmailSubjectTextbox.Text = ReconstructMessage(Globals.EmailSubject, Globals.EmailSubjectVariables);
        }

        private string ReconstructMessage(string text, List<string>variables)
        {
            StringBuilder result = new StringBuilder();
            bool getNextChar = false;
            bool greaterThanNine = false;
            bool skipNext = false;
            for (int i = 0; i < text.Length; i++)
            {
                if(skipNext)
                {
                    skipNext = false;
                    continue;
                }
                if(getNextChar)
                {
                    int index;
                    if (greaterThanNine)
                    {
                        index = Convert.ToInt32(text[i].ToString() + text[i + 1].ToString());
                        skipNext = true;
                    }
                    else
                    {
                        index = Convert.ToInt32(System.Char.GetNumericValue(text[i]));
                    }
                    result.Append("{" + variables[index] + "}");
                    if (index >= 9)
                        greaterThanNine = true;
                    getNextChar = false;
                    continue;
                }
                if (text[i] == '{')
                {
                    getNextChar = true;
                    continue;
                }
                if (text[i] == '}')
                    continue;
                result.Append(text[i]);
            }
            return result.ToString();
        }
    }
}
