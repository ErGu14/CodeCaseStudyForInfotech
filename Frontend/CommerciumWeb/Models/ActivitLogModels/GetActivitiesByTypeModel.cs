using System.Text.Json.Serialization;

public class GetActivitiesByTypeModel
{
    [JsonPropertyName("activityType")]
    public int ActivityType { get; set; } // Backend Enum alıyor
}
