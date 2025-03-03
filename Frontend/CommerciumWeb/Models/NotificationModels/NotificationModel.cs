using Commercium.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class NotificationModel
{
    [JsonPropertyName("notificationId")]
    public int NotificationId { get; set; } // RM ile uyumlu hale getirildi.

    [JsonPropertyName("userId")]
    [Required(ErrorMessage = "Kullanıcı ID'si gereklidir.")]
    public string UserId { get; set; }

    [JsonPropertyName("notificationType")]
    public NotificationType NotificationType { get; set; } // RM ile uyumlu hale getirildi.

    [JsonPropertyName("message")]
    [Required(ErrorMessage = "Bildirim içeriği gereklidir.")]
    [StringLength(1000, ErrorMessage = "Bildirim içeriği en fazla 1000 karakter olabilir.")]
    public string Message { get; set; }

    [JsonPropertyName("isRead")]
    public bool IsRead { get; set; } = false;

    [JsonPropertyName("dateCreated")]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow; // RM ile uyum sağlandı.

    [JsonPropertyName("productId")]
    public int? ProductId { get; set; }

    [JsonPropertyName("serviceId")]
    public int? ServiceId { get; set; }

    [JsonPropertyName("businessProfileId")]
    public int? BusinessProfileId { get; set; }
}
