using System.Text.Json.Serialization;

public class GetActivityByIdModel
{
    [JsonPropertyName("activityLogId")]
    public int ActivityLogId { get; set; }
}
