namespace CommerciumWeb.Models.SearchModels
{
    using System;
    using System.Text.Json.Serialization;

    namespace Commercium.MVC.Models
    {
        public class SearchResultModel
        {
            [JsonPropertyName("searchResultId")]
            public int SearchResultId { get; set; }

            [JsonPropertyName("searchQuery")]
            public string SearchQuery { get; set; }

            [JsonPropertyName("productId")]
            public int? ProductId { get; set; }

            [JsonPropertyName("product")]
            public ProductModel Product { get; set; }

            [JsonPropertyName("serviceId")]
            public int? ServiceId { get; set; }

            [JsonPropertyName("service")]
            public BusinessServiceModel Service { get; set; }

            [JsonPropertyName("businessProfileId")]
            public int? BusinessProfileId { get; set; }

            [JsonPropertyName("businessProfile")]
            public BusinessProfileModel BusinessProfile { get; set; }

            [JsonPropertyName("searchDate")]
            public DateTime SearchDate { get; set; }
        }
    }

}
