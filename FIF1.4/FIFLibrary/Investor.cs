using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFLibrary
{
    public class Investor
    {
        private int InvestorID;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Deceased { get; set; }
        public DateTime JoinDate { get; set; }
        public string LabelName { get; set; }
        public string Notes { get; set; }
        public string LastInvestYear { get; set; }

        private List<Investment> Investments;



        //This constructor is used when creating a new investor
        public Investor(string firstName, string lastName, string address, 
            string city, string state, string zip, string phone, string email, 
            bool deceased, string joinDate, string notes)
        {
            this.InvestorID = Globals.ID;
            Globals.ID--;

            this.FirstName = firstName;
            this.LastName = lastName;
            this.LabelName = string.Format("{0}, {1}", lastName, firstName);
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Phone = phone;
            this.Email = email;
            this.Deceased = deceased;
            this.JoinDate = Convert.ToDateTime(joinDate);
            this.Notes = notes;
            this.LastInvestYear = DateTime.Now.Year.ToString();
            this.Investments = new List<Investment>();
        }

        //This constructor is used when creating an investor from the database
        public Investor(string investorID, string firstName, string lastName, string address,
            string city, string state, string zip, string phone, string email,
            string deceased, string joinDate, string notes, string lastInvestYear, string labelName)
        {
            int ID;
            try
            {
                if (Int32.TryParse(investorID, out ID))
                {
                    this.InvestorID = ID;
                }
                else
                    throw new Exception("Could not parse investor ID from string to integer.");
                this.FirstName = firstName;
                this.LastName = lastName;
                this.LabelName = labelName;
                this.Address = address;
                this.City = city;
                this.State = state;
                this.Zip = zip;
                this.Phone = phone;
                this.Email = email;

                if (deceased == "0")
                {
                    this.Deceased = false;
                }
                else
                    this.Deceased = true;

                this.JoinDate = Convert.ToDateTime(joinDate);
                this.Notes = notes;
                this.LastInvestYear = lastInvestYear;
                this.Investments = new List<Investment>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("There was a problem loading Investors from the database.  \nError message: {0}", ex.Message));
            }
        }
        public Investor()
        {
            this.InvestorID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.LabelName = "";
            this.Address = "";
            this.City = "";
            this.State = "";
            this.Zip = "";
            this.Phone = "";
            this.Email = "";
            this.Deceased = false;
            this.JoinDate = default(DateTime);
            this.Notes = "";
            this.LastInvestYear = default(DateTime).ToString();
            this.Investments = new List<Investment>();
        }

        public int getID () {return this.InvestorID;}
        public void addInvestment(Investment i)
        {
            Investments.Add(i);
        }
        public List<Investment> getInvestments()
        {
            return Investments;
        }

        public void deleteInvestment(int investmentID)
        {
            Investments.Remove(Investments.Where(i => i.InvestmentID == investmentID).First());
        }
    }
}
