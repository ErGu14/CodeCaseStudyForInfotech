using Commercium.Shared.Businness.BusinessProfileRMs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.BusinessProfileCustomizationRMs
{
    public class BusinessProfileCustomizationRM
    {
        public int BusinessProfileCustomizationId { get; set; }
        public string CustomProfileImage { get; set; }
        public string CustomBackgroundImage { get; set; }
        public string CustomDescription { get; set; }

        public int BusinessProfileId { get; set; }
        public BusinessProfileRM BusinessProfile { get; set; }
    }
}
