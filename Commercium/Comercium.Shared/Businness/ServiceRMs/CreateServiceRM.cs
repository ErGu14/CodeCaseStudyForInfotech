using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.ServiceRMs
{
    public class CreateServiceRM
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ClickCount { get; set; } = 0;
        public int ViewCount { get; set; } = 0;

        public int LikeCount { get; set; } = 0;
        public int BusinessProfileId { get; set; }
        public int[] ServiceTagIds { get; set; }
    }
}
