using Commercium.Entity.User.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.User
{
    public class UserProfileCustomization
    {
        public int UserProfileCustomizationId { get; set; }
        public string CustomProfileImage { get; set; }  // Kullanıcı profil resmi
        public string CustomBackgroundImage { get; set; }  // Kullanıcı arka plan resmi
        public string CustomDescription { get; set; }  // Kullanıcıya ait açıklama

        // Kullanıcı bilgisi
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }


}
