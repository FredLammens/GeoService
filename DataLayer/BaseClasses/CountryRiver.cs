using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.BaseClasses
{
    public class CountryRiver
    {
        public int CountryId { get; set; }
        public DCountry Country { get; set; }
        public int RiverId { get; set; }
        public DRiver river { get; set; }

    }
}
