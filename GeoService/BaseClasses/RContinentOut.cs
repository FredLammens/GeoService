using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GeoService.BaseClasses
{
    public class RContinentOut
    {
        [JsonPropertyName("countryId")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("population")]
        public long Population { get; set; }
        [JsonPropertyName("countries")]
        public List<string> Countries { get; set; } = new List<string>();
        public RContinentOut() { }
    }
}
