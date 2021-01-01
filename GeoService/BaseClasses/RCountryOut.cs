using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeoService.BaseClasses
{
    public class RCountryOut
    {
        [JsonPropertyName("countryId")]
        public string CountryId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("population")]
        public int Population { get; set; }
        [JsonPropertyName("surface")]
        public float Surface { get; set; }
        [JsonPropertyName("continentId")]
        public string ContinentId { get; set; }
    }
}
