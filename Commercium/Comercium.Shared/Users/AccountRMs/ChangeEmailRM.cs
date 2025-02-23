using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.AccountRMs
{
    public class ChangeEmailRM
    {
        [Required(ErrorMessage = "Mevcut e-posta adresini girmeniz gerekmektedir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string CurrentEmail { get; set; }

        [Required(ErrorMessage = "Yeni e-posta adresini giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string NewEmail { get; set; }

        [Required(ErrorMessage = "E-posta doğrulama kodunu giriniz.")]
        public string VerificationCode { get; set; }
    }
}
