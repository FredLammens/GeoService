using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeoService.BaseClasses
{
    public class RCountryIn
    {
        [JsonPropertyName("countryId")]
        public int CountryId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("population")]
        public int Population { get; set; }
        [JsonPropertyName("surface")]
        public float Surface { get; set; }
        [JsonPropertyName("continentId")]
        public int ContinentId { get; set; }
        public RCountryIn() { }
    }
}
