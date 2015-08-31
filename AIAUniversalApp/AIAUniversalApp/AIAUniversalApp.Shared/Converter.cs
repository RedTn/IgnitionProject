using AIARestApi;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AIAUniversalApp
{
    public class Converter
    {
        public static ActiveQuoteViewModel convertQuoteToViewModel(Quote quote)
        {
            ActiveQuoteViewModel quoteVM = new ActiveQuoteViewModel();
            quoteVM.ClaimInLastFive = quote.ClaimInLastFive;
            quoteVM.CustomerAddress = quote.CustomerAddress;
            quoteVM.CustomerDob = quote.CustomerDob;
            quoteVM.CustomerName = quote.CustomerFirstName + " " + quote.CustomerLastName;
            quoteVM.CustomerPhone = quote.CustomerPhone;
            quoteVM.CustomerSsn = quote.CustomerSsn;
            quoteVM.ForceMultiDiscount = quote.ForceMultiDiscount;
            quoteVM.Id = quote.Id;
            quoteVM.MovingViolation = quote.MovingViolation;
            quoteVM.PreviousCarrier = quote.PreviousCarrier;
            quoteVM.Price = (double)quote.Price;
            quoteVM.State = quote.State;
            quoteVM.Submitted = quote.Submitted;
            quoteVM.SubmissionTime = quote.SubmissionTime.ToString().Split(' ')[0];
            quoteVM.User = quote.User;
            quoteVM.AIAUserId = quote.AIAUserId;
            ObservableCollection<DriverViewModel> dvmcollection = new ObservableCollection<DriverViewModel>();
            foreach (var driver in quote.Drivers)
            {
                dvmcollection.Add(Converter.convertDriverToDriverViewModel(driver));

            }
            quoteVM.Drivers = dvmcollection;
            ObservableCollection<VehicleViewModel> vvmcollection = new ObservableCollection<VehicleViewModel>();
            foreach (var vehicle in quote.Vehicles)
            {
                vvmcollection.Add(Converter.convertVehicletoVehicleViewModel(vehicle));
            }
            quoteVM.Vehicles = vvmcollection;
            return quoteVM;

        }
        public static Quote convertViewModelToQuote(ActiveQuoteViewModel quoteVM)
        {
            Quote quote = new Quote();
            quote.ClaimInLastFive = quoteVM.ClaimInLastFive;
            quote.CustomerAddress = quoteVM.CustomerAddress;
            quote.CustomerDob = quoteVM.CustomerDob;
            quote.CustomerFirstName = quoteVM.CustomerName.Split(' ')[0];
            quote.CustomerLastName = quoteVM.CustomerName.Split(' ')[1];
            quote.CustomerPhone = quoteVM.CustomerPhone;
            quote.CustomerSsn = quoteVM.CustomerSsn;
            quote.ForceMultiDiscount = quoteVM.ForceMultiDiscount;
            quote.Id = quoteVM.Id;
            quote.MovingViolation = quoteVM.MovingViolation;
            quote.PreviousCarrier = quoteVM.PreviousCarrier;
            quote.Price = (decimal)quoteVM.Price;
            quote.State = quoteVM.State;
            quote.Submitted = quoteVM.Submitted;
            var times = quoteVM.SubmissionTime.Split('/');
            quote.SubmissionTime = new DateTime(Convert.ToInt32(times[1]), Convert.ToInt32(times[0]), Convert.ToInt32(times[2]));
            quote.User = quoteVM.User;
            quote.AIAUserId = quoteVM.AIAUserId;
            ObservableCollection<Driver> drivers = new ObservableCollection<Driver>();
            foreach (var driver in quoteVM.Drivers)
            {
                drivers.Add(Converter.convertDriverViewModelToDriver(driver));
            }
            quote.Drivers = drivers;
            ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();
            foreach (var vehicle in quoteVM.Vehicles)
            {
                vehicles.Add(Converter.convertVehicleViewModelToVehicle(vehicle));
            }
            quote.Drivers = drivers;
            quote.Vehicles = vehicles;

            return quote;

        }

        public static DriverViewModel convertDriverToDriverViewModel(Driver driver)
        {
            DriverViewModel dvm = new DriverViewModel();
            dvm.Address = driver.Address;
            dvm.Dob = driver.Dob;
            dvm.FirstName = driver.FirstName;
            dvm.Gender = (Gender)Enum.Parse(typeof(Gender), driver.Gender);
            dvm.ID = driver.Id;
            dvm.LastName = driver.LastName;
            dvm.LicenseDateStart = driver.LicenseDateStart;
            dvm.LicenseNumber = driver.LicenseNumber;
            dvm.LicenseState = (State)Enum.Parse(typeof(State), driver.LicenseState);
            dvm.MiddleInitial = driver.MiddleInitial;
            dvm.NameSuffix = driver.NameSuffix;
            dvm.NonDriver = driver.NonDriver;
            dvm.Phone = driver.Phone;
            dvm.QuoteID = driver.QuoteId;
            dvm.Relationship = driver.Relationship;
            dvm.SafeDrivingSchool = driver.SafeDrivingSchool;
            dvm.Ssn = driver.Ssn;
            return dvm;
        }
        public static Driver convertDriverViewModelToDriver(DriverViewModel dvm)
        {
            Driver d = new Driver();
            d.Address = dvm.Address;
            d.Dob = dvm.Dob.DateTime;
            d.FirstName = dvm.FirstName;
            d.Gender = (String)Enum.Parse(typeof(String), d.Gender);
            d.Id = dvm.ID;
            d.LastName = dvm.LastName;
            d.LicenseDateStart = dvm.LicenseDateStart.DateTime;
            d.LicenseNumber = dvm.LicenseNumber;
            d.LicenseState = Enum.GetName(typeof(State), dvm.LicenseState);
            d.MiddleInitial = dvm.MiddleInitial;
            d.NameSuffix = dvm.NameSuffix;
            d.NonDriver = dvm.NonDriver;
            d.Phone = dvm.Phone;
            d.QuoteId = dvm.QuoteID;
            d.Relationship = dvm.Relationship;
            d.SafeDrivingSchool = dvm.SafeDrivingSchool;
            d.Ssn = dvm.Ssn;

            return d;
        }
        public static VehicleViewModel convertVehicletoVehicleViewModel(Vehicle v)
        {
            VehicleViewModel vvm = new VehicleViewModel();
            vvm.AnnualMiles = (int)v.AnnualMiles;
            vvm.CurrentValue = v.CurrentValue;
            vvm.DaysDrivenPerWeek = v.DaysDrivenPerWeek;
            vvm.HasAntilockBrakingSystem = v.HasAntilockBrakingSystem;
            vvm.HasDaylightRunningLights = v.HasDaytimeRunningLights;
            vvm.Id = v.Id;
            vvm.Make = v.Make;
            vvm.Mileage = (int)v.Mileage;
            vvm.MilesDrivenToWork = (int)v.MilesDrivenToWork;
            vvm.CarModel = v.CarModel;
            vvm.DriverId = v.DriverId;
            vvm.ReducedUse = v.ReduceUse;
            vvm.Vin = v.Vin;
            vvm.Year = v.Year;
            vvm.HasAntiTheftSystem = v.AntiTheft;
            vvm.HasPassiveRestraints = v.PassiveRestraints;
            vvm.ParkedInSeparateGarage = v.GarageDifferent; 
            
            return vvm ; 
        }
        public static Vehicle convertVehicleViewModelToVehicle(VehicleViewModel vvm)
        {
            Vehicle v = new Vehicle();
            v.AnnualMiles = vvm.AnnualMiles;
            v.AntiTheft = vvm.HasAntiTheftSystem;
            v.CurrentValue = vvm.CurrentValue;
            v.DaysDrivenPerWeek = vvm.DaysDrivenPerWeek;
            v.GarageDifferent = vvm.ParkedInSeparateGarage;
            v.HasAntilockBrakingSystem = vvm.HasAntilockBrakingSystem;
            v.HasDaytimeRunningLights = vvm.HasDaylightRunningLights;
            v.Id = vvm.Id;
            v.Make = vvm.Make;
            v.Mileage = vvm.Mileage;
            v.MilesDrivenToWork = vvm.MilesDrivenToWork;
            v.CarModel = vvm.CarModel;
            v.PassiveRestraints = vvm.HasPassiveRestraints;
            v.DriverId = vvm.DriverId;
            v.ReduceUse = vvm.ReducedUse;
            v.Vin = vvm.Vin;
            v.Year = vvm.Year; 
            
            return v;
        }

    }
}
