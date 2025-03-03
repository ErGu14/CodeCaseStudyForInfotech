using System.Text.Json.Serialization;

namespace CommerciumWeb.Models.SearchModels
{
    public class SearchHistoryModel
    {
        [JsonPropertyName("searchHistoryId")]
        public int SearchHistoryId { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("searchQuery")]
        public string SearchQuery { get; set; }

        [JsonPropertyName("searchDate")]
        public DateTime SearchDate { get; set; }
    }
}
