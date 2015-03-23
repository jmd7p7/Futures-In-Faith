using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFLibrary
{
    public class Youth
    {
        public int YouthID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }

        public Youth()
        {
            this.YouthID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.FullName = "";
            this.IsActive = false;
        }

        //Use this when creating youth for the first time
        public Youth(string fName, string lName)
        {
            this.YouthID = Globals.ID;
            Globals.ID--;
            this.FirstName = fName;
            this.LastName = lName;
            this.FullName = string.Format("{0}, {1}", lName, fName);
            this.IsActive = true;
        }

        //use this constructed when getting youth from the database
        public Youth(int id, string fName, string lName, string fullName, bool active)
        {
            this.YouthID = id;
            this.FirstName = fName;
            this.LastName = lName;
            this.FullName = fullName;
            this.IsActive = active;
        }
    }
}
