using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CampaignModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("businessProfileId")]
    [Required(ErrorMessage = "İşletme profili ID gereklidir.")]
    public int BusinessProfileId { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Kampanya adı gereklidir.")]
    [StringLength(150, ErrorMessage = "Kampanya adı en fazla 150 karakter olabilir.")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    [StringLength(1000, ErrorMessage = "Kampanya açıklaması en fazla 1000 karakter olabilir.")]
    public string? Description { get; set; }

    [JsonPropertyName("startDate")]
    [Required(ErrorMessage = "Kampanya başlangıç tarihi gereklidir.")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("endDate")]
    [Required(ErrorMessage = "Kampanya bitiş tarihi gereklidir.")]
    public DateTime EndDate { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("products")]
    public List<int> Products { get; set; } = new();
}
