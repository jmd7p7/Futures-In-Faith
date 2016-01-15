using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.MessageBuilder;


namespace FIFLibrary.EmailMessage
{
    public class EmailVariablesManager : MessageVariablesManager 
    {
        public EmailVariablesManager()
            :base(new List<String>{
                "First Name",
                "Last Name",
                "Label Name",
                "Email",
                "Phone",
                "Address",
                "City",
                "State",
                "Zip",
                "Amount",
                "Certificate Number",
                "Investment Date",
                "Program Start Date",
                "Program End Date"
            }) {}


    }
}
