using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeoService.BaseClasses
{
    public class RContinentIn
    {
        /// <summary>
        /// Continent Name
        /// </summary>
        [JsonPropertyName("naam")]
        public string Name { get; set; }

        public RContinentIn() { }
    }
}
