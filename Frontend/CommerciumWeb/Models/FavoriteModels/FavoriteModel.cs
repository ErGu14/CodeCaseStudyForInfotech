using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class FavoriteModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("userId")]
    [Required(ErrorMessage = "Kullanıcı ID gereklidir.")]
    public string UserId { get; set; }

    [JsonPropertyName("productId")]
    public int? ProductId { get; set; } // Eğer favori ürünse

    [JsonPropertyName("serviceId")]
    public int? ServiceId { get; set; } // Eğer favori hizmetse

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Favoriye eklenme zamanı
}
