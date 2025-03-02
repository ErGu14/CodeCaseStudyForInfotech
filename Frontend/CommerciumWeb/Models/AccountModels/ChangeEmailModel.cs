using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ChangeEmailModel
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    [JsonPropertyName("currentEmail")]
    public string CurrentEmail { get; set; }

    [JsonPropertyName("newEmail")]
    public string NewEmail { get; set; }

    [JsonPropertyName("verificationCode")]
    public string VerificationCode { get; set; }
}
