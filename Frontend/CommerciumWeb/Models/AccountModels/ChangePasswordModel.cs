using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ChangePasswordModel
{
    [JsonPropertyName("userId")]
    [Required(ErrorMessage = "Kullanıcı kimliği gereklidir.")]
    public string UserId { get; set; }

    [JsonPropertyName("currentPassword")]
    [Required(ErrorMessage = "Mevcut şifre gereklidir.")]
    public string CurrentPassword { get; set; }

    [JsonPropertyName("newPassword")]
    [Required(ErrorMessage = "Yeni şifre gereklidir.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
    public string NewPassword { get; set; }

    [JsonPropertyName("confirmNewPassword")]
    [Required(ErrorMessage = "Yeni şifreyi onaylayın.")]
    [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
    public string ConfirmNewPassword { get; set; }
}
