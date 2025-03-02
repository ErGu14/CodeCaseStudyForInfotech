using Commercium.Shared.Enums;
using System.Text.Json.Serialization;

public class GetActivitiesByEntityModel
{
    [JsonPropertyName("entityId")]
    public int EntityId { get; set; }

    [JsonPropertyName("entityType")]
    public EntityType EntityType { get; set; } // Backend Enum alıyor
}
