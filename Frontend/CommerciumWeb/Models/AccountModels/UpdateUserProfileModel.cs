using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class UpdateUserProfileModel
{
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("userId")]
    public string UserId { get; set; }
}
