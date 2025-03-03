using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class BusinessProfileCustomizationModel
{
    [JsonPropertyName("businessProfileCustomizationId")]
    public int BusinessProfileCustomizationId { get; set; } // RM ile uyumlu hale getirildi.

    [JsonPropertyName("businessProfileId")]
    [Required(ErrorMessage = "İşletme ID gereklidir.")]
    public int BusinessProfileId { get; set; }

    [JsonPropertyName("customLogo")]
    public string? CustomLogo { get; set; } // `CustomProfileImage` ile eşleştirildi.

    [JsonPropertyName("customBanner")]
    public string? CustomBanner { get; set; } // `CustomBackgroundImage` ile eşleştirildi.

    [JsonPropertyName("customDescription")]
    public string? CustomDescription { get; set; } // Eksik olan açıklama eklendi.
}
