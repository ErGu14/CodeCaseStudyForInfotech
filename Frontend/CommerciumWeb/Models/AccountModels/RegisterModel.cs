namespace CommerciumWeb.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Commercium.Shared.Enums;
    using Newtonsoft.Json;


    namespace ECommerce.MVC.Models
    {
        public class RegisterModel
        {
            [JsonPropertyName("firstName")]
            [Required(ErrorMessage = "Ad gereklidir.")]
            [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
            public string FirstName { get; set; }

            [JsonPropertyName("lastName")]
            [Required(ErrorMessage = "Soyad gereklidir.")]
            [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
            public string LastName { get; set; }

            [JsonPropertyName("email")]
            [Required(ErrorMessage = "E-posta adresi gereklidir.")]
            [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
            [StringLength(100, ErrorMessage = "E-posta adresi en fazla 100 karakter olabilir.")]
            public string Email { get; set; }

            [JsonPropertyName("phoneNumber")]
            [Required(ErrorMessage = "Telefon numarası gereklidir.")]
            [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
            public string PhoneNumber { get; set; }

            [JsonPropertyName("password")]
            [Required(ErrorMessage = "Şifre gereklidir.")]
            [StringLength(100, MinimumLength = 8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
                ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
            public string Password { get; set; }

            [JsonPropertyName("confirmPassword")]
            [Required(ErrorMessage = "Şifreyi onaylayın.")]
            [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
            public string ConfirmPassword { get; set; }

            [JsonPropertyName("role")]
            public UserRole Role { get; set; } = UserRole.User; // Enum olarak düzeltilmiş

            [JsonPropertyName("status")]
            public UserStatus Status { get; set; } = UserStatus.PendingApproval; // Enum olarak düzeltilmiş
        }
    }

}
