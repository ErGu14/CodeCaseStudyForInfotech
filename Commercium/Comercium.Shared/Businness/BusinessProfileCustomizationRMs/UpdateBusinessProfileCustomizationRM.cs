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
        [Required(ErrorMessage = "Özelleştirme ID'si gereklidir.")]
        public int BusinessProfileCustomizationId { get; set; }

        public IFormFile? CustomProfileImage { get; set; }
        public IFormFile? CustomBackgroundImage { get; set; }

        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string? CustomDescription { get; set; }
    }
}
