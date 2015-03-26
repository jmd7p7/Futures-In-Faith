using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFLibrary
{
    public class Testing
    {

        #region //Testing the PDFCreator Class
        public bool runPDFCreatorTest()
        {
            bool success = false;
            PDFCreator pdfCreator = new PDFCreator(new Investor2(
                    _firstName: "Sally",
                    _lastName: "Johnson",
                    _investorID: "1",
                    _address: "123 Main Street",
                    _city: "Kansas City",
                    _state: "MO",
                    _zip: "64410",
                    _email: "SallyJohnson@SJ.Com",
                    _phone: "913-999-9999",
                    _deceased: "false",
                    _joinDate: default(DateTime).ToShortDateString(),
                    _labelName: "Johnson, Sally",
                    _notes: "",
                    _lastInvestYear: "2014"
                ));
            pdfCreator.createPDF(new Investment2(1,1,DateTime.Now.ToShortDateString(), 500, "A 123-623", "general fund", -1, "cash", "", "true"
                ), "print");
            return success;
        }
        

        #endregion
    }
}
