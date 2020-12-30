using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class CountryRiver
    {
        public int CountryKey { get; set; }
        public DCountry Country { get; set; }
        public int RiverKey { get; set; }
        public DRiver River { get; set; }
    }
}
