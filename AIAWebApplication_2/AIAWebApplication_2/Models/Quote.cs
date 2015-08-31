using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AIAWebApplication_2.Models
{
    public class Quote
    {

        public Quote()
        {
            Submitted = false;
            CustomerDob = DateTime.Now;
            CustomerPhone = "123-456-7890";
            CustomerSsn = "123-45-6789";
            SubmissionTime = DateTime.Now;
        }

        [Key]
        public long Id { get; set; }
        public int AIAUserId { get; set; }
        public decimal Price { get; set; }
        public bool Submitted { get; set; }  //Changed
        public DateTime? SubmissionTime { get; set; }
        [Required]
        [StringLength(2, ErrorMessage="State cannot be greater than 2")]
        public string State { get; set; }
        [Required]
        [Display(Name="Moving Violation in Last 5 Years")]
        public bool MovingViolation { get; set; }
        [Required]
        [Display(Name = "Previous Carrier")]
        [StringLength(50, ErrorMessage="PreviousCarrier cannot be greater than 50")]
        public string PreviousCarrier { get; set; }
        [Required]
        [Display(Name = "Claim in Last 5 Years")]
        public bool ClaimInLastFive { get; set; }
        [Required]
        [Display(Name = "Force a multi car discount")]
        public bool ForceMultiDiscount { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage="First Name cannot be greater than 30")]
        public string CustomerFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Last Name cannot be greater than 30")]
        public string CustomerLastName { get; set; }
        [Required]
        [Display(Name = "Address")]
        [StringLength(255, ErrorMessage = "Address cannot be greater than 255")]
        public string CustomerAddress { get; set; }
        [Required]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string CustomerPhone { get; set; }
        [Required]
        [Display(Name = "SSN")]
        [RegularExpression(@"^(\d{3}-?\d{2}-?\d{4}|XXX-XX-XXXX)$", ErrorMessage= "Entered SSN format is not valid")]
        public string CustomerSsn { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? CustomerDob { get; set; }

        [ScriptIgnore]
        public virtual ICollection<Driver> Drivers { get; set; }
        //public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}