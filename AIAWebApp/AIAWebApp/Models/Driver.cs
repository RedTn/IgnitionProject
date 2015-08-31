using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIAWebApp.Models
{
    public class Driver
    {
        //public Driver()
        //{
        //    this.Vehicles = new HashSet<Vehicle>();
        //}

        public Guid Id { get; set; }
        public string NameSuffix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Dob { get; set; }
        public string Ssn { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
        public string LicenseState { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseDateStart { get; set; }
        public bool SafeDrivingSchool { get; set; }
        //public System.Guid QuoteId { get; set; }

        //public virtual Quote Quote { get; set; }
        //public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}