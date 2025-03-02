using System.Text.Json.Serialization;

public class GetRecentUserActivitiesModel
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}
