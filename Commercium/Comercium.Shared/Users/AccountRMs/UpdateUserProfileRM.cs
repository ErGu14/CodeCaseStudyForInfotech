using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.AccountRMs
{
    public class UpdateUserProfileRM
    {
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string? FirstName { get; set; }

        [StringLength(50, ErrorMessage = "İkinci ad en fazla 50 karakter olabilir.")]
        public string? MiddleName { get; set; }

        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string? LastName { get; set; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string? PhoneNumber { get; set; }
    }
}
