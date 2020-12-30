using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeoService.BaseClasses
{
    public class RCountryOut
    {
        private string _countryId;
        [JsonPropertyName("countryId")]
        public string CountryId { get => _countryId; set => _countryId = Constants.apiUrl + value; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("population")]
        public int Population { get; set; }
        [JsonPropertyName("surface")]
        public float Surface { get; set; }
        private string _continentId;
        [JsonPropertyName("continentId")]
        public string ContinentId { get => _continentId; set => _continentId = Constants.apiUrl + value; }
    }
}
