using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class CountryRiver
    {
        public string CountryName { get; set; }
        public DCountry Country { get; set; }
        public string RiverName { get; set; }
        public DRiver River { get; set; }
    }
}
