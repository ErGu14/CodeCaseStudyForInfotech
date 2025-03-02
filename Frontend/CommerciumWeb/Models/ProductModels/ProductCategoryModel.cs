using System.Text.Json.Serialization;

namespace CommerciumWeb.Models.ProductModels
{
    public class ProductCategoryModel
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

    }
}
