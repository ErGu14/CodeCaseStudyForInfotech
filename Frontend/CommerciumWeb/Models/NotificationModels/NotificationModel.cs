using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class NotificationModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("userId")]
    [Required(ErrorMessage = "Kullanıcı ID'si gereklidir.")]
    public string UserId { get; set; }

    [JsonPropertyName("title")]
    [Required(ErrorMessage = "Bildirim başlığı gereklidir.")]
    [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
    public string Title { get; set; }

    [JsonPropertyName("message")]
    [Required(ErrorMessage = "Bildirim içeriği gereklidir.")]
    [StringLength(1000, ErrorMessage = "Bildirim içeriği en fazla 1000 karakter olabilir.")]
    public string Message { get; set; }

    [JsonPropertyName("isRead")]
    public bool IsRead { get; set; } = false;

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
