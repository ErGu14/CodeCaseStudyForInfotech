using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

public class CustomizeUserProfileModel
{
    [JsonPropertyName("userProfileCustomizationId")]
    public int UserProfileCustomizationId { get; set; }

    [JsonPropertyName("customProfileImage")]
    public IFormFile? CustomProfileImage { get; set; }

    [JsonPropertyName("customBackgroundImage")]
    public IFormFile? CustomBackgroundImage { get; set; }

    [JsonPropertyName("customDescription")]
    public string? CustomDescription { get; set; }

    [JsonPropertyName("userId")]
    public string UserId { get; set; }
}
