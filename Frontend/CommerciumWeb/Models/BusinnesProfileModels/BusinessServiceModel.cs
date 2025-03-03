using CommerciumWeb.Models.TagModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class BusinessServiceModel
{
    [JsonPropertyName("serviceId")]
    public int ServiceId { get; set; } // RM ile birebir uyumlu hale getirildi.

    [JsonPropertyName("serviceName")]
    [Required(ErrorMessage = "Hizmet adı gereklidir.")]
    [StringLength(100, ErrorMessage = "Hizmet adı en fazla 100 karakter olabilir.")]
    public string ServiceName { get; set; } // `Name` yerine `ServiceName` kullanıldı.

    [JsonPropertyName("description")]
    [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
    public string? Description { get; set; }

    [JsonPropertyName("price")]
    [Range(0, double.MaxValue, ErrorMessage = "Fiyat negatif olamaz.")]
    public decimal Price { get; set; }

    [JsonPropertyName("clickCount")]
    public int ClickCount { get; set; } 

    [JsonPropertyName("viewCount")]
    public int ViewCount { get; set; } 

    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; } 

    [JsonPropertyName("businessProfile")]
    public BusinessProfileModel BusinessProfile { get; set; } 

    [JsonPropertyName("reviews")]
    public List<ReviewModel>? Reviews { get; set; } 

    [JsonPropertyName("serviceTags")]
    public List<ServiceTagModel>? ServiceTags { get; set; } 
}