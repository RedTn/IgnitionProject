using AIARestApi;
using AIAUniversalApp.Shared.Helpers;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AIAUniversalApp
{
    public class ActiveQuoteViewModel : BaseViewModel
    {
        public ObservableCollection<DriverViewModel> Drivers { get; set; }
        public ObservableCollection<VehicleViewModel> Vehicles { get; set; }

        public ActiveQuoteViewModel()
        {
            if (Drivers == null)
            {
                Drivers = new ObservableCollection<DriverViewModel>();
            }

            if (Vehicles == null)
            {
                Vehicles = new ObservableCollection<VehicleViewModel>();
            }
        }

        public ActiveQuoteViewModel(bool newQuote) : this()
        {
            q = Helper.Post(new Quote(newQuote));
        }

        public long Id { get; set; }
        public int AIAUserId { get; set; }
        public double Price { get; set; }
        public bool Submitted { get; set; }
        public string SubmissionTime { get; set; }
        public string State { get; set; }
        public bool MovingViolation { get; set; }
        public string PreviousCarrier { get; set; }
        public bool ClaimInLastFive { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerSsn { get; set; }
        public System.DateTime CustomerDob { get; set; }
        public bool ForceMultiDiscount { get; set; }

        //public virtual ICollection<Driver> Drivers { get; set; }
       // public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual AIAUser User { get; set; }
        public Quote q { get; set; }
    }
}
