using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.BusinessProfileCustomizationRMs
{
    public class CreateBusinessProfileCustomizationRM
    {
        [Required(ErrorMessage = "Profil resmi URL'si gereklidir.")]
        public IFormFile CustomProfileImage { get; set; }

        [Required(ErrorMessage = "Arka plan resmi URL'si gereklidir.")]
        public IFormFile CustomBackgroundImage { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string CustomDescription { get; set; }

        [Required(ErrorMessage = "İşletme profili ID'si gereklidir.")]
        public int BusinessProfileId { get; set; }
    }
}
