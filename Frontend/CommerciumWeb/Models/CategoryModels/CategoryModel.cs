using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CategoryModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Kategori adı gereklidir.")]
    [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    [StringLength(500, ErrorMessage = "Kategori açıklaması en fazla 500 karakter olabilir.")]
    public string? Description { get; set; }

    [JsonPropertyName("parentCategoryId")]
    public int? ParentCategoryId { get; set; }

    [JsonPropertyName("productCount")]
    public int ProductCount { get; set; }

    [JsonPropertyName("subCategories")]
    public List<CategoryModel>? SubCategories { get; set; }
}
