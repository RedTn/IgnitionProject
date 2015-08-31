using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIAWebApp.Models
{
    public class VehicleViewModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Mileage { get; set; }
        public int CurrentValue { get; set; }
        public int DaysDrivenPerWeek { get; set; }
        public string Vin { get; set; }
        public decimal AnnualMiles { get; set; }
        public bool HasDaytimeRunningLights { get; set; }
        public bool HasAntilockBrakingSystem { get; set; }
        public bool PassiveRestraints { get; set; }
        public bool AntiTheft { get; set; }
        public bool ReduceUse { get; set; }
        public bool GarageDifferent { get; set; }
        public decimal MilesDrivenToWork { get; set; }
    }
}