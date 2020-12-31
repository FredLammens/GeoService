using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeoService.BaseClasses
{
    public class RContinentIn
    {
        /// <summary>
        /// Continent Name
        /// </summary>
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        public RContinentIn() { }
    }
}
