using CommerciumWeb.Models.ProductModels;
using CommerciumWeb.Models.TagModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class TagModel
{
    [JsonPropertyName("tagId")]
    public int TagId { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Etiket adı boş olamaz.")]
    [StringLength(100, ErrorMessage = "Etiket adı en fazla 100 karakter olabilir.")]
    public string Name { get; set; }

    [JsonPropertyName("productTags")]
    public List<ProductTagModel>? ProductTags { get; set; }

    [JsonPropertyName("serviceTags")]
    public List<ServiceTagModel>? ServiceTags { get; set; }

    [JsonPropertyName("businessProfileTags")]
    public List<BusinessProfileTagModel>? BusinessProfileTags { get; set; }
}