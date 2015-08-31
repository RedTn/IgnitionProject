using AIARestApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace AIAUniversalApp.ViewModels
{
    public class VehicleViewModel : BaseViewModel
    {
        public ObservableCollection<DriverViewModel> Drivers { get; set; }

        public VehicleViewModel()
        {
        }

        public VehicleViewModel(ObservableCollection<DriverViewModel> observableCollection)
        {
            // TODO: Complete member initialization
            this.Drivers = observableCollection;
        }
        public long Id { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string CarModel { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int CurrentValue { get; set; }
        public int AnnualMiles { get; set; }
        public bool HasDaylightRunningLights { get; set; }
        public bool HasAntilockBrakingSystem { get; set; }
        public bool HasPassiveRestraints { get; set; }
        public bool HasAntiTheftSystem { get; set; }
        public bool ReducedUse { get; set; }
        public bool ParkedInSeparateGarage { get; set; }
        public int MilesDrivenToWork { get; set; }
        public int DaysDrivenPerWeek { get; set; }
        public long DriverId { get; set; }
    }
}
