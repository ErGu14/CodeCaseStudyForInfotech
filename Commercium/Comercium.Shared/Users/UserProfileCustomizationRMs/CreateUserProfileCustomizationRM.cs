using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.UserProfileCustomizationRMs
{
    public class CreateUserProfileCustomizationRM
    {
        [Required(ErrorMessage = "Profil resmi gereklidir.")]
        public IFormFile CustomProfileImage { get; set; }  // Kullanıcı profil resmi dosyası

        [Required(ErrorMessage = "Arka plan resmi gereklidir.")]
        public IFormFile CustomBackgroundImage { get; set; }  // Kullanıcı arka plan resmi dosyası

        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string CustomDescription { get; set; }  // Kullanıcı açıklaması

        [Required(ErrorMessage = "Kullanıcı ID gereklidir.")]
        public string UserId { get; set; }
    }

}
