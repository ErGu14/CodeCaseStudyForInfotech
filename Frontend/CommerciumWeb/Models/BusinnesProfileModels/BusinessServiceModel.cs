using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class BusinessServiceModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("businessProfileId")]
    [Required(ErrorMessage = "İşletme ID gereklidir.")]
    public int BusinessProfileId { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Hizmet adı gereklidir.")]
    [StringLength(100, ErrorMessage = "Hizmet adı en fazla 100 karakter olabilir.")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
    public string? Description { get; set; }

    [JsonPropertyName("price")]
    [Range(0, double.MaxValue, ErrorMessage = "Fiyat negatif olamaz.")]
    public decimal Price { get; set; }
}
