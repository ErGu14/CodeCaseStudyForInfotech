using Commercium.Shared.Businness.BusinessProfileTagRMs;
using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.BusinessProfileRMs
{
    public class BusinessProfileRM
    {
        public int BusinessProfileId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessDescription { get; set; }
        public string ContactInfo { get; set; }
        public string Location { get; set; }

        public int ClickCount { get; set; }
        public int LikeCount { get; set; }

        public string OwnerId { get; set; }
        public AppUserRM Owner { get; set; }

        public IEnumerable<ProductRM> Products { get; set; }
        public IEnumerable<ServiceRM> Services { get; set; }
        public IEnumerable<BusinessProfileTagRM> BusinessProfileTags { get; set; }
    }
}
