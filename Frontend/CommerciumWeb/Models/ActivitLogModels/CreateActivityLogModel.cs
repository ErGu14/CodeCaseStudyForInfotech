using Commercium.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CreateActivityLogModel
{
    [JsonPropertyName("userId")]
    [Required(ErrorMessage = "Kullanıcı ID gereklidir.")]
    public string UserId { get; set; }

    [JsonPropertyName("entityId")]
    public int EntityId { get; set; }

    [JsonPropertyName("entityType")]
    [Required(ErrorMessage = "Varlık tipi gereklidir.")]
    public EntityType EntityType { get; set; } // Backend Enum alıyor

    [JsonPropertyName("activityType")]
    [Required(ErrorMessage = "Aktivite tipi gereklidir.")]
    public ActivityType ActivityType { get; set; } // Backend Enum alıyor

    [JsonPropertyName("description")]
    [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
    public string? Description { get; set; }
}
