using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


public class UserModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; } // Kullanıcının benzersiz ID'si

    [JsonPropertyName("firstName")]
    [Required(ErrorMessage = "Ad bilgisi gereklidir.")]
    [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
    public string FirstName { get; set; }

    [JsonPropertyName("middleName")]
    [StringLength(50, ErrorMessage = "İkinci ad en fazla 50 karakter olabilir.")]
    public string? MiddleName { get; set; }

    [JsonPropertyName("lastName")]
    [Required(ErrorMessage = "Soyad bilgisi gereklidir.")]
    [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
    public string LastName { get; set; }

    [JsonPropertyName("email")]
    [Required(ErrorMessage = "E-posta adresi gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir.")]
    public string Email { get; set; }

    [JsonPropertyName("phoneNumber")]
    [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("role")]
    [Required(ErrorMessage = "Rol bilgisi gereklidir.")]
    public int Role { get; set; } // Kullanıcı rolü (Admin, User, BusinessOwner vb.)

    [JsonPropertyName("status")]
    [Required(ErrorMessage = "Kullanıcı durumu gereklidir.")]
    public int Status { get; set; } // Kullanıcı hesabının durumu (PendingApproval, Active, Suspended vb.)

    [JsonPropertyName("profileImageUrl")]
    public string? ProfileImageUrl { get; set; } // Kullanıcı profil resmi URL

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Kullanıcı hesabının oluşturulma tarihi

    [JsonPropertyName("lastLoginAt")]
    public DateTime? LastLoginAt { get; set; } // Son giriş zamanı (Opsiyonel)

    [JsonPropertyName("followers")]
    public List<UserModel>? Followers { get; set; } // Kullanıcının takipçileri

    [JsonPropertyName("following")]
    public List<UserModel>? Following { get; set; } // Kullanıcının takip ettiği kişiler
}
