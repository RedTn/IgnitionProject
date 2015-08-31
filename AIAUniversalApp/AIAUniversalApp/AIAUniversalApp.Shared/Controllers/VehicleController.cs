using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIAUniversalApp.ViewModels;
using AIARestApi;
using Windows.UI.Xaml.Controls;
using AIAUniversalApp.Shared.Helpers;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace AIAUniversalApp.Controllers
{
    public class VehicleController: BaseController
    {
        public VehicleViewModel VehicleViewModel;
        private ObservableCollection<DriverViewModel> observableCollection;
        
        public VehicleController()
        {
            VehicleViewModel = new VehicleViewModel();
        }

        public VehicleController(ObservableCollection<DriverViewModel> observableCollection, long quoteId, long pDriverId)
        {
            this.observableCollection = observableCollection;
            VehicleViewModel = new VehicleViewModel(observableCollection);
            VehicleViewModel.Id = Helper.Post(new Vehicle(quoteId, pDriverId)).Id;
        }

        public Vehicle Save(long quoteId)
        {
            Vehicle v = new Vehicle();
            v.Id = VehicleViewModel.Id;
            v.AnnualMiles = VehicleViewModel.AnnualMiles;
            v.AntiTheft = VehicleViewModel.HasAntiTheftSystem;
            v.CurrentValue = VehicleViewModel.CurrentValue;
            v.DaysDrivenPerWeek = VehicleViewModel.DaysDrivenPerWeek;
            v.GarageDifferent = VehicleViewModel.ParkedInSeparateGarage;
            v.HasAntilockBrakingSystem = VehicleViewModel.HasAntilockBrakingSystem;
            v.HasDaytimeRunningLights = VehicleViewModel.HasDaylightRunningLights;
            v.Make = VehicleViewModel.Make;
            v.Mileage = VehicleViewModel.Mileage;
            v.MilesDrivenToWork = VehicleViewModel.MilesDrivenToWork;
            v.CarModel = VehicleViewModel.CarModel;
            v.PassiveRestraints = VehicleViewModel.HasPassiveRestraints;
            v.ReduceUse = VehicleViewModel.ReducedUse;
            v.Vin = VehicleViewModel.Vin;
            v.Year = VehicleViewModel.Year;
            v.DriverId = VehicleViewModel.DriverId;
            v.QuoteId = quoteId;
            v.Quote = Helper.Get<Quote>(quoteId);

            return Helper.Put(v, v.Id);
        }

        public void Cancel()
        {
            throw new System.NotImplementedException();
        }

        public void ShowVehicleDetail(long id)
        {
            Vehicle vehicle = Helper.Get<Vehicle>(id);

            VehicleViewModel.Id = vehicle.Id;
            VehicleViewModel.AnnualMiles = (int)vehicle.AnnualMiles;
            VehicleViewModel.CurrentValue = vehicle.CurrentValue;
            VehicleViewModel.DaysDrivenPerWeek = vehicle.DaysDrivenPerWeek;
            VehicleViewModel.HasAntilockBrakingSystem = vehicle.HasAntilockBrakingSystem;  
            VehicleViewModel.HasDaylightRunningLights = vehicle.HasDaytimeRunningLights;
            VehicleViewModel.HasAntiTheftSystem = vehicle.AntiTheft;
            VehicleViewModel.Make = vehicle.Make;
            VehicleViewModel.Mileage = (int)vehicle.Mileage;
            VehicleViewModel.MilesDrivenToWork = (int)vehicle.MilesDrivenToWork;
            VehicleViewModel.CarModel = vehicle.CarModel;
            VehicleViewModel.ReducedUse = vehicle.ReduceUse;
            VehicleViewModel.HasPassiveRestraints = vehicle.PassiveRestraints;
            VehicleViewModel.ParkedInSeparateGarage = vehicle.GarageDifferent;
            VehicleViewModel.Vin = vehicle.Vin;
            VehicleViewModel.Year = vehicle.Year;
        }
    }
}
