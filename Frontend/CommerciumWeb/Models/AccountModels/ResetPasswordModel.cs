using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ResetPasswordModel
{
    [JsonPropertyName("email")]
    [Required(ErrorMessage = "E-posta adresi gereklidir.")]
    public string Email { get; set; }

    [JsonPropertyName("resetToken")]
    [Required(ErrorMessage = "Şifre sıfırlama kodu gereklidir.")]
    public string ResetToken { get; set; }

    [JsonPropertyName("newPassword")]
    [Required(ErrorMessage = "Yeni şifre gereklidir.")]
    public string NewPassword { get; set; }

    [JsonPropertyName("confirmNewPassword")]
    [Required(ErrorMessage = "Yeni şifreyi onaylayın.")]
    [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
    public string ConfirmNewPassword { get; set; }
}
