using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class BusinessTagModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("businessProfileId")]
    [Required(ErrorMessage = "İşletme ID gereklidir.")]
    public int BusinessProfileId { get; set; }

    [JsonPropertyName("tag")]
    [Required(ErrorMessage = "Etiket adı gereklidir.")]
    [StringLength(50, ErrorMessage = "Etiket en fazla 50 karakter olabilir.")]
    public string Tag { get; set; }
}
