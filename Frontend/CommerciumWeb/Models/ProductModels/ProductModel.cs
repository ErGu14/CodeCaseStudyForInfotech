using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ProductModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

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

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("categoryIds")]
    public List<int>? CategoryIds { get; set; }  // Ürün birden fazla kategoriye ait olabilir

    [JsonPropertyName("tagIds")]
    public List<int>? TagIds { get; set; }  // Ürün birden fazla etikete sahip olabilir

    [JsonPropertyName("businessProfileId")]
    [Required(ErrorMessage = "İşletme profili ID'si gereklidir.")]
    public int BusinessProfileId { get; set; }

    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; } = 0;

    [JsonPropertyName("clickCount")]
    public int ClickCount { get; set; } = 0;

    [JsonPropertyName("viewCount")]
    public int ViewCount { get; set; } = 0;

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
