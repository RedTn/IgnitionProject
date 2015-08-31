using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIAWebApplication_2.Models
{
    public class AgentSearchModel
    {
        public long? Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public bool? Submitted { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}