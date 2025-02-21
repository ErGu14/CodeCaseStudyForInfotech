using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity
{
    public class BusinessProfileCustomization
    {
        public int BusinessProfileCustomizationId { get; set; }
        public string CustomBackgroundImage { get; set; }  // İşletme arka plan resmi
        public string CustomDescription { get; set; }      // İşletme açıklaması

        public BusinessProfile BusinessProfile { get; set; }
    }

}
