using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFLibrary
{
    public class Investor2
    {
        public int InvestorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Deceased { get; set; }
        public DateTime JoinDate { get; set; }
        public string LabelName { get; set; }
        public string Notes { get; set; }
        public string LastInvestYear { get; set; }

        public Investor2()
        {
            this.InvestorID = -1;
            this.FirstName = "";
            this.LabelName = "";
            this.Address = "";
            this.City = "";
            this.State = "";
            this.Zip = "";
            this.Email = "";
            this.Phone = "";
            this.Deceased = false;
            this.JoinDate = default(DateTime);
            this.LabelName = "";
            this.Notes = "";
            this.LastInvestYear = "";
        }

        public Investor2(string _investorID, string _firstName, string _lastName, string _address,
            string _city, string _state, string _zip, string _email, string _phone, string _deceased, 
            string _joinDate, string _labelName, string _notes, string _lastInvestYear)
        {
            //Following variables are used when attempting to parse certain string parameters to the appropriate data types
            int outInvestorID;
            DateTime outJoinDate;

            if(Int32.TryParse(_investorID, out outInvestorID))
            {
                this.InvestorID = outInvestorID;
            }
            else
            {
                this.InvestorID = -1;
            }
            this.FirstName = _firstName;
            this.LastName = _lastName;
            this.Address = _address;
            this.City = _city;
            this.State = _state;
            this.Zip = _zip;
            this.Email = _email;
            this.Phone = _phone;
            if(_deceased == "0")
            {
                this.Deceased = false;
            }
            else
            {
                this.Deceased = true;
            }
            if (DateTime.TryParse(_joinDate, out outJoinDate))
            {
                this.JoinDate = outJoinDate;
            }
            else
            {
                this.JoinDate = default(DateTime);
            }
            this.LabelName = _labelName;
            this.Notes = _notes;
            this.LastInvestYear = _lastInvestYear;
        }
    }
}
