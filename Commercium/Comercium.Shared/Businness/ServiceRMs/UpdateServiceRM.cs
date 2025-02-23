using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.ServiceRMs
{
    public class UpdateServiceRM
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BusinessProfileId { get; set; }
        public int[] ServiceTagIds { get; set; }
    }
}
