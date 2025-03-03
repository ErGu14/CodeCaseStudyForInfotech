using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class FavoriteModel
{
    [JsonPropertyName("favoriteId")]
    public int FavoriteId { get; set; } // RM ile uyumlu hale getirildi.

    [JsonPropertyName("userId")]
    [Required(ErrorMessage = "Kullanıcı ID gereklidir.")]
    public string UserId { get; set; }

    [JsonPropertyName("productId")]
    public int? ProductId { get; set; } // Eğer favori ürünse

    [JsonPropertyName("serviceId")]
    public int? ServiceId { get; set; } // Eğer favori hizmetse
}