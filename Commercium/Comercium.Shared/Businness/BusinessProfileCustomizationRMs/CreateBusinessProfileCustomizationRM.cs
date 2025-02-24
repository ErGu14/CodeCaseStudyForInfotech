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
        [Required(ErrorMessage = "Profil resmi gereklidir.")]
        public IFormFile CustomProfileImage { get; set; }  // İşletme profil resmi dosyası

        [Required(ErrorMessage = "Arka plan resmi gereklidir.")]
        public IFormFile CustomBackgroundImage { get; set; }  // İşletme arka plan resmi dosyası

        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string CustomDescription { get; set; }  // İşletme açıklaması

        [Required(ErrorMessage = "İşletme profili ID gereklidir.")]
        public int BusinessProfileId { get; set; }
    }

}
