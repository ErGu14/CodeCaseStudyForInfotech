using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.BusinessProfileCustomizationRMs
{
    public class UpdateBusinessProfileCustomizationRM
    {
        [Required(ErrorMessage = "İşletme profil özelleştirme ID gereklidir.")]
        public int BusinessProfileCustomizationId { get; set; }

        public IFormFile? CustomProfileImage { get; set; }  // Opsiyonel profil resmi dosyası
        public IFormFile? CustomBackgroundImage { get; set; }  // Opsiyonel arka plan resmi dosyası

        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string? CustomDescription { get; set; }  // Opsiyonel açıklama

        [Required(ErrorMessage = "İşletme profili ID gereklidir.")]
        public int BusinessProfileId { get; set; }
    }

}
