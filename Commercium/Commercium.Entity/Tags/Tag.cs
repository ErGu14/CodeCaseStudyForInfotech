using Commercium.Entity.Businness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.Tags
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; }
        public ICollection<ServiceTag> ServiceTags { get; set; }
        public ICollection<BusinessProfileTag> BusinessProfileTags { get; set; }
    }

}
