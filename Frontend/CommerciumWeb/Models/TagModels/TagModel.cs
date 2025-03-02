using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class TagModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; } // Etiket ID

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Etiket adı boş olamaz.")]
    [StringLength(100, ErrorMessage = "Etiket adı en fazla 100 karakter olabilir.")]
    public string Name { get; set; } // Etiket adı

    [JsonPropertyName("description")]
    [StringLength(255, ErrorMessage = "Açıklama en fazla 255 karakter olabilir.")]
    public string? Description { get; set; } // Opsiyonel açıklama

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Etiket oluşturulma tarihi

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; } // Etiket güncellenme tarihi (opsiyonel)

    [JsonPropertyName("products")]
    public List<ProductModel>? Products { get; set; } // Etiket ile bağlantılı ürünler

    [JsonPropertyName("services")]
    public List<BusinessServiceModel>? Services { get; set; } // Etiket ile bağlantılı hizmetler

    [JsonPropertyName("businesses")]
    public List<BusinessProfileModel>? Businesses { get; set; } // Etiket ile bağlantılı işletmeler
}
