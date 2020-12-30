using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.BaseClasses
{
    public class Constants
    {
        public static string apiUrl { get; private set; }
        public Constants(IConfiguration iconfiguation)
        {
            apiUrl = iconfiguation.GetValue<string>("profiles:GeoService:applicationUrl");
        }
    }
}
