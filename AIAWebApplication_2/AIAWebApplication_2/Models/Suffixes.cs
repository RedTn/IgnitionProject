using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIAWebApplication_2.Models
{
    public static class Suffixes
    {
        public static string[] GetSuffixes()
        {
            return new string[] 
            {
                "B.V.M.",
                "CFRE",
                "CLU",
                "CPA",
                "C.S.C.",
                "C.S.J.",
                "D.C.",
                "D.D.",
                "D.D.S.",
                "D.M.D."
                //TODO: Finish "https://www.lehigh.edu/lewis/suffix.htm"
            };
        }
    }
}