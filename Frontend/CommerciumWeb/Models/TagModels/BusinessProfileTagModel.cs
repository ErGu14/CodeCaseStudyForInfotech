using System.Text.Json.Serialization;

namespace CommerciumWeb.Models.TagModels
{
    public class BusinessProfileTagModel
    {
        [JsonPropertyName("businessProfileId")]
        public int BusinessProfileId { get; set; }

        [JsonPropertyName("businessProfile")]
        public BusinessProfileModel BusinessProfile { get; set; }

        [JsonPropertyName("tagId")]
        public int TagId { get; set; }

        [JsonPropertyName("tag")]
        public TagModel Tag { get; set; }
    }
}
