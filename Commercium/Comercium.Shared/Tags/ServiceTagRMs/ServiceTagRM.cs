using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.Tags.TagRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Tags.ServiceTagRMs
{
    public class ServiceTagRM
    {
        public int ServiceId { get; set; }
        public ServiceRM Service { get; set; }
        public int TagId { get; set; }
        public TagRM Tag { get; set; }
    }
}
