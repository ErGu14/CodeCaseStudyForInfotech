using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.Businness
{
    public class BusinessProfileCustomization
    {
        public int BusinessProfileCustomizationId { get; set; }
        public string CustomProfileImage { get; set; }  // İşletme profil resmi
        public string CustomBackgroundImage { get; set; }  // İşletme arka plan resmi
        public string CustomDescription { get; set; }  // İşletme açıklaması

        // İlişkili işletme profili
        public int BusinessProfileId { get; set; }
        public BusinessProfile BusinessProfile { get; set; }
    }


}
