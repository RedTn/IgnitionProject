using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIAWebApplication_2.Models
{
    public class Driver
    {
        public Driver()
        {
            Dob = DateTime.Now;
            LicenseDateStart = DateTime.Now;
            Phone = "123-456-7890";
            Ssn = "123-45-6789";
        }

        [Key]
        public long Id { get; set; }
        [Display(Name = "Name Suffix")]
        [StringLength(5, ErrorMessage="Suffix cannot be longer than 5")]
        public string NameSuffix { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage="Firstname cannot be longer than 30")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage="LastName cannot be longer than 30")]
        public string LastName { get; set; }
        [Display(Name = "Middle Initial")]
        [StringLength(1, ErrorMessage="Inital cannot be greater than 1")]
        public string MiddleInitial { get; set; }
        [Required]
        [StringLength(255, ErrorMessage="Address cannot be greater length than 255")]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Dob { get; set; }
        [Required]
        [Display(Name = "SSN")]
        [RegularExpression(@"^(\d{3}-?\d{2}-?\d{4}|XXX-XX-XXXX)$", ErrorMessage = "Entered SSN format is not valid")]
        public string Ssn { get; set; }
        [Required]
        [StringLength(1, ErrorMessage="Gender length must be 1")]
        public string Gender { get; set; }
        [Required]
        [StringLength(15, ErrorMessage="Relationship cannot be greater than 15")]
        public string Relationship { get; set; }
        [Required]
        [Display(Name = "License State")]
        [StringLength(2, ErrorMessage="State cannot be greater than 2")]
        public string LicenseState { get; set; }
        [Required]
        [Display(Name = "License Number")]
        [StringLength(20, ErrorMessage="LicenseNumber cannot be greater than 20")]
        public string LicenseNumber { get; set; }
        [Required]
        [Display(Name = "License Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime LicenseDateStart { get; set; }
        [Required]
        [Display(Name = "Safe Driving School")]
        public bool SafeDrivingSchool { get; set; }
        public bool NonDriver { get; set; }

        [Required]
        public long QuoteId { get; set; }
        public virtual Quote Quote { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}