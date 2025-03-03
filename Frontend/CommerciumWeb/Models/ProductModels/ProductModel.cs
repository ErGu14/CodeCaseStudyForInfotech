using CommerciumWeb.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ProductModel
{
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Ürün adı gereklidir.")]
    [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olabilir.")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
    public string? Description { get; set; }

    [JsonPropertyName("price")]
    [Required(ErrorMessage = "Fiyat gereklidir.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
    public decimal Price { get; set; }

    [JsonPropertyName("clickCount")]
    public int ClickCount { get; set; }

    [JsonPropertyName("viewCount")]
    public int ViewCount { get; set; }

    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; }

    [JsonPropertyName("businessProfile")]
    public BusinessProfileModel BusinessProfile { get; set; }

    [JsonPropertyName("reviews")]
    public List<ReviewModel>? Reviews { get; set; }

    [JsonPropertyName("productCategories")]
    public List<ProductCategoryModel> ProductCategories { get; set; }

    [JsonPropertyName("productTags")]
    public List<ProductModel> ProductTags { get; set; }
}