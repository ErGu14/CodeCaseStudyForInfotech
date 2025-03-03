using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class BusinessTagModel
{
    [JsonPropertyName("businessProfileId")]
    [Required(ErrorMessage = "İşletme ID gereklidir.")]
    public int BusinessProfileId { get; set; }

    [JsonPropertyName("tagId")]
    [Required(ErrorMessage = "Etiket ID gereklidir.")]
    public int TagId { get; set; } // Eksik olan `TagId` eklendi.

    [JsonPropertyName("tag")]
    public TagModel Tag { get; set; } // `Tag` nesne olarak eklendi.
}
