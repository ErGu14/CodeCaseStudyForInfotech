namespace CommerciumWeb.Models
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;


    namespace ECommerce.MVC.Models
    {
        public class RegisterModel
        {
            [JsonProperty("firstName")]
            [Required(ErrorMessage = "Ad gereklidir.")]
            [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
            [Display(Name = "Ad")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            [Required(ErrorMessage = "Soyad gereklidir.")]
            [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
            [Display(Name = "Soyad")]
            public string LastName { get; set; }

            [JsonProperty("email")]
            [Required(ErrorMessage = "E-posta adresi gereklidir.")]
            [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
            [StringLength(100, ErrorMessage = "E-posta adresi en fazla 100 karakter olabilir.")]
            [Display(Name = "E-Posta Adresi")]
            public string Email { get; set; }

            [JsonProperty("phoneNumber")]
            [Required(ErrorMessage = "Telefon numarası gereklidir.")]
            [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
            [Display(Name = "Telefon Numarası")]
            public string PhoneNumber { get; set; }

            [JsonProperty("password")]
            [Required(ErrorMessage = "Şifre gereklidir.")]
            [StringLength(100, MinimumLength = 8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
                ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
            [DataType(DataType.Password)]
            [Display(Name = "Şifre")]
            public string Password { get; set; }

            [JsonProperty("confirmPassword")]
            [Required(ErrorMessage = "Şifreyi onaylayın.")]
            [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
            [DataType(DataType.Password)]
            [Display(Name = "Şifreyi Onayla")]
            public string ConfirmPassword { get; set; }

            [JsonProperty("role")]
            [Display(Name = "Kullanıcı Rolü")]
            public string Role { get; set; } = "User"; // Varsayılan değer User

            [JsonProperty("status")]
            [Display(Name = "Kullanıcı Durumu")]
            public string Status { get; set; } = "PendingApproval"; // Her zaman PendingApproval olacak
        }
    }

}
