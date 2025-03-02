using System.Text.Json.Serialization;

namespace CommerciumWeb.Models.ProductModels
{
    public class ProductTagModel
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("tagId")]
        public int TagId { get; set; }

       

    }
}
