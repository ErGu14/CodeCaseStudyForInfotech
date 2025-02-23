using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Tags.TagRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.BusinessProfileTagRMs
{
    public class BusinessProfileTagRM
    {
        public int BusinessProfileId { get; set; }
        public BusinessProfileRM BusinessProfile { get; set; }

        public int TagId { get; set; }
        public TagRM Tag { get; set; }
    }

}
