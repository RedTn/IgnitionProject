using AIAUniversalApp.Shared.Helpers;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIARestApi;
using Windows.UI.Xaml.Controls;
using System.Windows.Input; 

namespace AIAUniversalApp.Controllers
{
    public class DriverController : BaseController
    {
        public DriverViewModel DriverViewModel { get; set; }

        public DriverController(long quoteId)
        {
            DriverViewModel = new DriverViewModel();
            DriverViewModel.ID = Helper.Post(new Driver(quoteId)).Id;
        }


        public Driver Save(long quoteId)
        {
            Driver d = new Driver();
            d.Id = DriverViewModel.ID;
            d.Address = DriverViewModel.Address;
            d.Dob = DriverViewModel.Dob.DateTime;
            d.FirstName = DriverViewModel.FirstName;
            d.Gender = Enum.GetName(typeof(Gender), DriverViewModel.Gender);
            d.LastName = DriverViewModel.LastName;
            d.LicenseDateStart = DriverViewModel.LicenseDateStart.DateTime;
            d.LicenseNumber = DriverViewModel.LicenseNumber;
            d.LicenseState = Enum.GetName(typeof(State), DriverViewModel.LicenseState);
            d.MiddleInitial = DriverViewModel.MiddleInitial;
            d.NameSuffix = DriverViewModel.NameSuffix;
            d.Phone = DriverViewModel.Phone;
            d.Relationship = DriverViewModel.Relationship;
            d.SafeDrivingSchool = DriverViewModel.SafeDrivingSchool;
            d.Ssn = DriverViewModel.Ssn;
            d.QuoteId = quoteId;
         
            return Helper.Put(d, d.Id);
        }

        public void Cancel()
        {
            throw new System.NotImplementedException();
        }

        public void ShowDriverDetail(long id)
        {
            Driver driver = Helper.Get<Driver>(id);
            DriverViewModel.Address = driver.Address;
            DriverViewModel.Dob = driver.Dob;
            DriverViewModel.FirstName = driver.FirstName;
            DriverViewModel.Gender = (Gender)Enum.Parse(typeof(Gender), driver.Gender);
            DriverViewModel.ID = driver.Id;
            DriverViewModel.LastName = driver.LastName;
            DriverViewModel.LicenseDateStart = driver.LicenseDateStart;
            DriverViewModel.LicenseNumber = driver.LicenseNumber;
            DriverViewModel.LicenseState = (State)Enum.Parse(typeof(State), driver.LicenseState);
            DriverViewModel.MiddleInitial = driver.MiddleInitial;
            DriverViewModel.NameSuffix = driver.NameSuffix;
            DriverViewModel.Phone = driver.Phone;
            DriverViewModel.QuoteID = driver.QuoteId;
            DriverViewModel.Relationship = driver.Relationship;
            DriverViewModel.SafeDrivingSchool = driver.SafeDrivingSchool;
            DriverViewModel.Ssn = driver.Ssn;
          
        }


    }
}
