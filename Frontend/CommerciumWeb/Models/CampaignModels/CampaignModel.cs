using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CampaignModel
{
    [JsonPropertyName("campaignId")]
    public int CampaignId { get; set; } 

    [JsonPropertyName("businessProfileId")]
    public int BusinessProfileId { get; set; } 

    [JsonPropertyName("title")]
    [Required(ErrorMessage = "Kampanya başlığı gereklidir.")]
    [StringLength(150, ErrorMessage = "Başlık en fazla 150 karakter olabilir.")]
    public string Title { get; set; } 

    [JsonPropertyName("description")]
    [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
    public string? Description { get; set; }

    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime EndDate { get; set; }

    [JsonPropertyName("discountPercentage")]
    [Range(0, 100, ErrorMessage = "İndirim oranı 0 ile 100 arasında olmalıdır.")]
    public decimal DiscountPercentage { get; set; } 

    [JsonPropertyName("clickCount")]
    public int ClickCount { get; set; } 

    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; } 

    [JsonPropertyName("viewCount")]
    public int ViewCount { get; set; } 

   

    [JsonPropertyName("products")]
    public List<ProductModel>? Products { get; set; } 
}
