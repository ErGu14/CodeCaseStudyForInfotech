using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.UserProfileCustomizationRMs
{
    public class UserProfileCustomizationRM
    {
        public int UserProfileCustomizationId { get; set; }
        public string CustomProfileImage { get; set; }  // Kullanıcı profil resmi
        public string CustomBackgroundImage { get; set; }  // Kullanıcı arka plan resmi
        public string CustomDescription { get; set; }  // Kullanıcı açıklaması

        public string UserId { get; set; }
        public AppUserRM User { get; set; }
    }

}
