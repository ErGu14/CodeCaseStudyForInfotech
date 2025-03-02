using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ReviewModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("userId")]
    [Required(ErrorMessage = "Kullanıcı ID gereklidir.")]
    public string UserId { get; set; }

    [JsonPropertyName("productId")]
    public int? ProductId { get; set; } // Ürün yorumu için kullanılır

    [JsonPropertyName("serviceId")]
    public int? ServiceId { get; set; } // Hizmet yorumu için kullanılır

    [JsonPropertyName("rating")]
    [Required(ErrorMessage = "Puan gereklidir.")]
    [Range(1, 5, ErrorMessage = "Puan 1 ile 5 arasında olmalıdır.")]
    public int Rating { get; set; }  // 1 ile 5 arasında bir puan

    [JsonPropertyName("comment")]
    [StringLength(1000, ErrorMessage = "Yorum en fazla 1000 karakter olabilir.")]
    public string? Comment { get; set; } // Opsiyonel yorum metni

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Varsayılan olarak UTC zamanı

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }
}
