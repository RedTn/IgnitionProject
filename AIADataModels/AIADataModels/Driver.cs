//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AIADataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Driver
    {
        public System.Guid Id { get; set; }
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
        public System.Guid QuoteId { get; set; }
    
        public virtual Quote Quote { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
