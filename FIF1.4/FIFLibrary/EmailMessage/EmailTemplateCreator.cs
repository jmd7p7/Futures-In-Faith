using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FIFLibrary;
using Common.StringManipulation;

namespace FIFLibrary.EmailMessage
{
    public class EmailTemplateCreator
    {
        private String Subject;
        private String Message;

        public EmailTemplateCreator(String subject, String message)
        {
            if(String.IsNullOrEmpty(subject) || String.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentException("Null or empty string is now allowed for the email subject.  Please provide some text.");
            }
            if (String.IsNullOrEmpty(message) || String.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Null or empty string is now allowed for the email message.  Please provide some text.");
            }
            this.Subject = subject;
            this.Message = message;
        }

        public void save()
        {
            saveMessageBody();
            saveSubject();
        }

        private void saveSubject()
        {
            DBCommunication.saveEmailSubject(this.Subject);
        }

        private void saveMessageBody()
        {
            DBCommunication.saveEmailMessage(this.Message);
        }

    }
}
