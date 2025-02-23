using Commercium.Shared.Businness.BusinessProfileTagRMs;
using Commercium.Shared.Tags.ServiceTagRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Tags.TagRMs
{
    public class TagRM
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductTagRMs.ProductTagRM> ProductTags { get; set; }
        public IEnumerable<ServiceTagRM> ServiceTags { get; set; }
        public IEnumerable<BusinessProfileTagRM> BusinessProfileTags { get; set; }
    }
}
