using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;

using System.Text.Json.Serialization;

namespace CommerciumWeb.Models
{
    public class ReturnModel<T>
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("errors")]
        public List<string>? Errors { get; set; }
    }
}