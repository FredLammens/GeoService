using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Name { get; set; }
        [JsonPropertyName("population")]
        [Required]
        public int Population { get; set; }
        [JsonPropertyName("surface")]
        [Required]
        public float Surface { get; set; }
        [JsonPropertyName("continentId")]
        [Required]
        public int ContinentId { get; set; }
        public RCountryIn() { }
    }
}
