using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIAWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CanUseSystem { get; set; }
    }
}