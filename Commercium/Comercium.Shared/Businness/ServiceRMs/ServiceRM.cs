using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Tags.ServiceTagRMs;
using Commercium.Shared.Users.ReviewRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.ServiceRMs
{
    public class ServiceRM
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ClickCount { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public BusinessProfileRM BusinessProfile { get; set; }
        public IEnumerable<ReviewRM> Reviews { get; set; }
        public IEnumerable<ServiceTagRM> ServiceTags { get; set; }
    }
}
