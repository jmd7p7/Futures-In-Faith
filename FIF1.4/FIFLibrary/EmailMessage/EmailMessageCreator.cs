using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.MessageBuilder;
using System.Threading.Tasks;

namespace FIFLibrary.EmailMessage
{
    public class EmailMessageCreator
    {
        EmailVariablesManager messageVariablesManager;
        IMessageVariablesProvider[] messageVariablesProvider;

        public EmailMessageCreator(IMessageVariablesProvider[] messageVariablesProvider)
        {
            try
            {
                this.messageVariablesManager = new EmailVariablesManager();
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            
            this.messageVariablesProvider = messageVariablesProvider;
        }

        public String getInjectedEmailMessage()
        {
            String injectedEmailMessage;
            try
            {
                injectedEmailMessage = buildInjectedMessage(DBCommunication.getEmailMessage());
                return Common.StringManipulation.StringFormatter.replaceNewlineWithHTMLBreak(injectedEmailMessage);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        public String getInjectedEmailSubject()
        {
            String injectedEmailSubject;
            try
            {
                injectedEmailSubject = buildInjectedMessage(DBCommunication.getEmailSubject());
                return injectedEmailSubject;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private string buildInjectedMessage(String text)
        {
            CurlyBracesMessageBuilder builder = new CurlyBracesMessageBuilder();
            try
            {
                String injectedMessage = 
                    builder.buildInjectedMessage(text, messageVariablesManager.getVariablesAndTheirValues(messageVariablesProvider));
                return injectedMessage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
