using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DiscConnectedApi.Models
{
    public class Forum
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
