using System.Text.Json.Serialization;

public class GetActivitiesByEntityModel
{
    [JsonPropertyName("entityId")]
    public int EntityId { get; set; }

    [JsonPropertyName("entityType")]
    public int EntityType { get; set; } // Backend Enum alıyor
}
