using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FIFLibrary
{
    public class EmailMessageBuilder
    {
        private string Subject;
        private string MessageBody;

        public EmailMessageBuilder(string _subject, string _messageBody)
        {
            Subject = _subject;
            MessageBody = _messageBody;
        }

        public bool CreateEmailBody() 
        {
            if (ParseMessage(EmailText: MessageBody, isBody: true))
                return true;
            return false;
        }
        public bool CreateEmailSubject()
        {
            if (ParseMessage(EmailText: Subject, isBody: false))
                return true;
            return false;
        }


        private bool ParseMessage(string EmailText, bool isBody)
        {

            Regex variablePattern = new Regex(@"({\w+})");
            MatchCollection matches = variablePattern.Matches(EmailText);
            List<string> parsedVariables = matches.Cast<Match>().Select(match => match.Value).ToList();
            int index = 0;
            foreach (string match in parsedVariables)
            {
                Regex currentWordPattern = new Regex(match);
                EmailText = currentWordPattern.Replace(EmailText, "{" + index + "}");
                index++;
            }

            for (int i = 0; i < parsedVariables.Count; i++)
            {
                parsedVariables[i] = parsedVariables[i].Substring(1, parsedVariables[i].Length - 2);

            }

            StringBuilder variables = new StringBuilder();
            foreach(string s in parsedVariables)
            {
                variables.Append(s + ",");
            }

            Regex singleQuote = new Regex(@"(')");
            if(isBody)
            {
                if (DBCommunication.SaveEmailSubjectOrMessageToDB(singleQuote.Replace(EmailText, "''"), variables.ToString().Substring(0, variables.Length - 1), false))
                {
                    Globals.EmailMessage = EmailText.ToString();
                    Globals.EmailMessageVariables = parsedVariables;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (DBCommunication.SaveEmailSubjectOrMessageToDB(EmailText, variables.ToString().Substring(0, variables.Length - 1), true))
                {
                    Globals.EmailSubject = EmailText.ToString();
                    Globals.EmailSubjectVariables = parsedVariables;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
