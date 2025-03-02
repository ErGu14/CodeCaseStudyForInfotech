using Commercium.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ActivityLogModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("userId")]
    [Required(ErrorMessage = "Kullanıcı ID gereklidir.")]
    public string UserId { get; set; }

    [JsonPropertyName("entityId")]
    public int EntityId { get; set; }

    [JsonPropertyName("entityType")]
    public EntityType EntityType { get; set; } // Backend Enum olarak alıyor

    [JsonPropertyName("activityType")]
    public ActivityType ActivityType { get; set; } // Backend Enum olarak alıyor

    [JsonPropertyName("description")]
    [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
    public string? Description { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}
