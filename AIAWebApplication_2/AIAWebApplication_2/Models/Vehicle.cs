using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AIAWebApplication_2.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            Year = 1000;
            DaysDrivenPerWeek = 0;
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage="Make cannot be longer than 20")]
        public string Make { get; set; }
        [Required]
        [Display(Name = "Model")]
        [StringLength(20, ErrorMessage="CarModel cannot be longer than 20")]
        public string CarModel { get; set; }
        [Required]
        [Range(1000, 9999, ErrorMessage="Year must be 4 digits")]
        public int Year { get; set; }
        [Required]
        [Display(Name = "Total Mileage")]
        public decimal Mileage { get; set; }
        [Display(Name = "Current Value")]
        public int CurrentValue { get; set; }
        [Required]
        [Display(Name = "Days Driven Per Week")]
        [Range(0, 7, ErrorMessage="Days must be in the range of 0 to 7 inclusive")]
        public int DaysDrivenPerWeek { get; set; }
        [Required]
        [Display(Name = "VIN")]
        [StringLength(30, ErrorMessage="VIN cannot be greater than 30")]
        public string Vin { get; set; }
        [Required]
        [Display(Name = "Annual Mileage")]
        public decimal AnnualMiles { get; set; }
        [Required]
        [Display(Name = "Daytime Running Light")]
        public bool HasDaytimeRunningLights { get; set; }
        [Required]
        [Display(Name = "Anti-Lock Brakes")]
        public bool HasAntilockBrakingSystem { get; set; }
        [Required]
        [Display(Name = "Passive Restraints")]
        public bool PassiveRestraints { get; set; }
        [Required]
        [Display(Name = "Anti-Theft")]
        public bool AntiTheft { get; set; }
        [Required]
        [Display(Name = "Reduced Used Discount")]
        public bool ReduceUse { get; set; }
        [Required]
        [Display(Name = "Garage Address Different")]
        public bool GarageDifferent { get; set; }
        [Required]
        [Display(Name = "Miles Driven To Work")]
        public decimal MilesDrivenToWork { get; set; }

        [Required]
        [Display(Name = "Primary Driver")]
        public long DriverId { get; set; }
        [Required]
        public long QuoteId { get; set; }
    }
}