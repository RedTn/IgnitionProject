using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIAWebApplication_2.Models
{
    public enum SystemStatus {
        Rejected,
        Approved,
        Pending
    }

    public class AIAUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage="First Name must be less than 30")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Last Name must be less than 30")]
        public string LastName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "User Name must be less than 30")]
        public string UserName { get; set; }
        [Required]
        public int CanUseSystem { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    }
}