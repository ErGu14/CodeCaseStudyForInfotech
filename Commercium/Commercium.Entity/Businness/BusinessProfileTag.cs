using Commercium.Entity.Tags;
using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Tags.TagRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.Businness
{
    public class BusinessProfileTag
    {
        public int BusinessProfileId { get; set; }
        public BusinessProfile BusinessProfile { get; set; }

        public int TagId { get; set; }
        public TagRM Tag { get; set; }
    }


}
