using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIAWebApplication_2.Models
{
    public static class States
    {
        public static string[] GetStates() 
        {
            return new string[] {
                "VT",
                "ME",
                "MA",
                "NH",
                "CT",
                "PA",
                "NY",
                "SC",
                "WV",
                "VA"
            };
        }
    }
}