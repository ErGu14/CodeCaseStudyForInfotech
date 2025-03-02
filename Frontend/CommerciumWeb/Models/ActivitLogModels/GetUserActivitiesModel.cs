using System.Text.Json.Serialization;

public class GetUserActivitiesModel
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; }
}
