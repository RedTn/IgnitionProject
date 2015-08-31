//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AIARestApi
{
    using AIAUniversalApp.Shared.Helpers;
    using System;
    using System.Collections.Generic;

    public partial class Driver
    {
        public Driver()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }

        public Driver(long qId)
        {
            this.Vehicles = new HashSet<Vehicle>();
            this.NameSuffix = "Emp";
            this.FirstName = "Emp";
            this.LastName = "Emp";
            this.MiddleInitial = "E";
            this.Address = "Empt";
            this.Phone = "0";
            this.Dob = DateTime.Now;
            this.Ssn = "Empt";
            this.Gender = "m";
            this.Relationship = "Empt";
            this.LicenseState = "NA";
            this.LicenseNumber = "Empt";
            this.LicenseDateStart = DateTime.Now;
            this.SafeDrivingSchool = true;
            this.QuoteId = qId;
            this.NonDriver = false;

        }

        public long Id { get; set; }
        public string NameSuffix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public System.DateTime Dob { get; set; }
        public string Ssn { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
        public string LicenseState { get; set; }
        public string LicenseNumber { get; set; }
        public System.DateTime LicenseDateStart { get; set; }
        public bool SafeDrivingSchool { get; set; }
        public long QuoteId { get; set; }
        public bool NonDriver { get; set; }

        public virtual Quote Quote { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}