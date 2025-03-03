using Commercium.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ActivityLogModel
{
    [JsonPropertyName("id")]
    public int ActivityLogId { get; set; }

    [JsonPropertyName("userId")]
    [Required(ErrorMessage = "Kullanıcı ID gereklidir.")]
    public string UserId { get; set; }

    [JsonPropertyName("entityId")]
    public int EntityId { get; set; }

    [JsonPropertyName("entityType")]
    [Required(ErrorMessage = "Varlık tipi gereklidir.")]
    public EntityType EntityType { get; set; } // Enum olarak kaldı.

    [JsonPropertyName("activityType")]
    [Required(ErrorMessage = "Aktivite tipi gereklidir.")]
    public ActivityType ActivityType { get; set; }

    [JsonPropertyName("details")]
    [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
    public string? Details { get; set; }

    [JsonPropertyName("activityDate")]
    public DateTime ActivityDate { get; set; } // RM ile uyumlu hale getirildi.

    [JsonPropertyName("entityName")]
    public string? EntityName { get; set; } // RM'deki `EntityName` eklendi.

    [JsonPropertyName("productId")]
    public int? ProductId { get; set; }

    [JsonPropertyName("serviceId")]
    public int? ServiceId { get; set; }
}
