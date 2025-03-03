using CommerciumWeb.Models.ProductModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CategoryModel
{
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; } 

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Kategori adı gereklidir.")]
    [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
    public string Name { get; set; }

    [JsonPropertyName("productCategories")]
    public List<ProductCategoryModel>? ProductCategories { get; set; } 
}
