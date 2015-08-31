using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace AIAUniversalApp.ViewModels
{
    public class DriverViewModel : BaseViewModel
    {
        public long ID { get; set; }
        public string NameSuffix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset Dob { get; set; }
        public string Ssn { get; set; }
        public string Relationship { get; set; }
        public State LicenseState { get; set; }
        public string LicenseNumber { get; set; }
        public DateTimeOffset LicenseDateStart { get; set; }
        public bool SafeDrivingSchool { get; set; }
        public long QuoteID { get; set; }
        public bool NonDriver { get; set; }
        public Gender Gender { get; set; }
           
    }
}
