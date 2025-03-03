using Commercium.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


public class UserModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; } // Kullanıcının benzersiz ID'si

    [JsonPropertyName("firstName")]
    [Required(ErrorMessage = "Ad bilgisi gereklidir.")]
    [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    [Required(ErrorMessage = "Soyad bilgisi gereklidir.")]
    [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
    public string LastName { get; set; }

    [JsonPropertyName("email")]
    [Required(ErrorMessage = "E-posta adresi gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir.")]
    public string Email { get; set; }

    [JsonPropertyName("emailConfirmed")]
    public bool EmailConfirmed { get; set; } // E-posta doğrulama durumu

    [JsonPropertyName("role")]
    [Required(ErrorMessage = "Rol bilgisi gereklidir.")]
    public UserRole Role { get; set; } // Kullanıcı rolü (Admin, User, BusinessOwner vb.)

    [JsonPropertyName("status")]
    [Required(ErrorMessage = "Kullanıcı durumu gereklidir.")]
    public UserStatus Status { get; set; } // Kullanıcı hesabının durumu (PendingApproval, Active, Suspended vb.)

    [JsonPropertyName("businessProfiles")]
    public List<BusinessProfileModel>? BusinessProfiles { get; set; } // Kullanıcının işletme profilleri

    [JsonPropertyName("followers")]
    public List<UserFollowModel>? Followers { get; set; } // Kullanıcının takipçileri

    [JsonPropertyName("following")]
    public List<UserFollowModel>? Following { get; set; } // Kullanıcının takip ettiği kişiler
}