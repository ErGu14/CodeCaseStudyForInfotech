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
        public string CustomProfileImage { get; set; }
        public string CustomBackgroundImage { get; set; }

        public string CustomDescription { get; set; }

        public BusinessProfile BusinessProfile { get; set; }
    }

}
