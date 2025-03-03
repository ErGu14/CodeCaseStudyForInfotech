using System.Text.Json.Serialization;

namespace CommerciumWeb.Models.TagModels
{
    public class ServiceTagModel
    {
        [JsonPropertyName("serviceId")]
        public int ServiceId { get; set; }
        public BusinessServiceModel Service { get; set; }

        [JsonPropertyName("tagId")]
        public int TagId { get; set; }
        public TagModel Tag { get; set; }
    }
}
