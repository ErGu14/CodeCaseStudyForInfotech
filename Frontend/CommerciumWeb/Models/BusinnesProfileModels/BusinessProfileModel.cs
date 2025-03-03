using CommerciumWeb.Models.TagModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class BusinessProfileModel
{
    [JsonPropertyName("businessProfileId")]
    public int BusinessProfileId { get; set; } // RM ile uyumlu hale getirildi.

    [JsonPropertyName("businessName")]
    [Required(ErrorMessage = "İşletme adı gereklidir.")]
    [StringLength(100, ErrorMessage = "İşletme adı en fazla 100 karakter olabilir.")]
    public string BusinessName { get; set; } // `Name` yerine `BusinessName` kullanıldı.

    [JsonPropertyName("businessDescription")]
    [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
    public string? BusinessDescription { get; set; } // `Description` yerine RM ile uyumlu hale getirildi.

    [JsonPropertyName("ownerId")]
    [Required(ErrorMessage = "İşletme sahibi gereklidir.")]
    public string OwnerId { get; set; }

    [JsonPropertyName("contactInfo")]
    public string? ContactInfo { get; set; } // Eksik olan alan eklendi.

    [JsonPropertyName("location")]
    public string? Location { get; set; } // Eksik olan alan eklendi.

    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; } 

    [JsonPropertyName("viewCount")]
    public int ViewCount { get; set; } 

    [JsonPropertyName("clickCount")]
    public int ClickCount { get; set; } 

    [JsonPropertyName("products")]
    public List<ProductModel>? Products { get; set; } // Eksik olan alan eklendi.

    [JsonPropertyName("services")]
    public List<BusinessServiceModel>? Services { get; set; } // Eksik olan alan eklendi.

    [JsonPropertyName("businessProfileTags")]
    public List<BusinessProfileTagModel>? BusinessProfileTags { get; set; } // Eksik olan alan eklendi.
}
