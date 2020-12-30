using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeoService.BaseClasses
{
    public class RContinentOut
    {
        private string _Id;
        [JsonPropertyName("countryId")]
        public string Id { get => _Id; set => _Id = Constants.apiUrl + value; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("population")]
        public long Population { get; set; }
        [JsonPropertyName("countries")]
        public List<string> Countries { get; set; } = new List<string>();
        public RContinentOut() { }
    }
}
