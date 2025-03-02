using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class BusinessProfileCustomizationModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("businessProfileId")]
    [Required(ErrorMessage = "İşletme ID gereklidir.")]
    public int BusinessProfileId { get; set; }

    [JsonPropertyName("customLogo")]
    public string? CustomLogo { get; set; }

    [JsonPropertyName("customBanner")]
    public string? CustomBanner { get; set; }
}
