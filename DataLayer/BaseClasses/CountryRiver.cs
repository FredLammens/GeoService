using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class CountryRiver
    {
        public uint CountryId { get; set; }
        public DCountry Country { get; set; }
        public uint RiverId { get; set; }
        public DRiver River { get; set; }

    }
}
