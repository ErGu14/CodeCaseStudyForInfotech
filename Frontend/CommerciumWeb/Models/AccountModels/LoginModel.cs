using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CommerciumWeb.Models.AccountModels
{
    public class LoginModel
    {
        [JsonProperty("email")]
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(100, ErrorMessage = "E-posta adresi en fazla 100 karakter olabilir.")]
        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; }

        [JsonProperty("password")]
        [Required(ErrorMessage = "Şifre gereklidir.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
