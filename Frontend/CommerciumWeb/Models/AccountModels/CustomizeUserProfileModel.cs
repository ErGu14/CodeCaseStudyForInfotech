using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

public class CustomizeUserProfileModel
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    [JsonPropertyName("firstName")]
    [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
    public string? FirstName { get; set; }

    [JsonPropertyName("middleName")]
    [StringLength(50, ErrorMessage = "İkinci ad en fazla 50 karakter olabilir.")]
    public string? MiddleName { get; set; }

    [JsonPropertyName("lastName")]
    [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
    public string? LastName { get; set; }

    [JsonPropertyName("phoneNumber")]
    [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("customProfileImage")]
    public IFormFile? CustomProfileImage { get; set; }

    [JsonPropertyName("customBackgroundImage")]
    public IFormFile? CustomBackgroundImage { get; set; }

    [JsonPropertyName("customDescription")]
    public string? CustomDescription { get; set; }
}
