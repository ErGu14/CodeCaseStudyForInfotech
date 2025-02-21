using Commercium.Entity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity
{
    public class UserProfileCustomization
    {
        public int UserProfileCustomizationId { get; set; }
        public string CustomBackgroundImage { get; set; }  // Kullanıcı arka plan resmi
        public string CustomDescription { get; set; }      // Kullanıcı açıklaması

        public AppUser User { get; set; }
    }

}
