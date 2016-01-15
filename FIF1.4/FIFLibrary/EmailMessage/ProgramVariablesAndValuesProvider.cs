using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.MessageBuilder;

namespace FIFLibrary.EmailMessage
{
    public class ProgramVariablesAndValuesProvider : IMessageVariablesProvider
    {

        public Dictionary<string, string> getDictionaryOfVariablesAndValues()
        {
            return new Dictionary<string, string>(){
                {"Program Start Date", Globals.ProgramStartDate.ToShortDateString()},
                {"Program End Date", Globals.ProgramEndDate.ToShortDateString()}
            };
        }
    }
}
