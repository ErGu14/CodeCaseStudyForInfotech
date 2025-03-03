using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ResetPasswordModel
{
    [JsonPropertyName("email")]
    [Required(ErrorMessage = "E-posta adresi gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    public string Email { get; set; }

    [JsonPropertyName("resetToken")]
    [Required(ErrorMessage = "Şifre sıfırlama kodu gereklidir.")]
    public string ResetToken { get; set; }

    [JsonPropertyName("newPassword")]
    [Required(ErrorMessage = "Yeni şifre gereklidir.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
    public string NewPassword { get; set; }

    [JsonPropertyName("confirmNewPassword")]
    [Required(ErrorMessage = "Yeni şifreyi onaylayın.")]
    [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
    public string ConfirmNewPassword { get; set; }
}