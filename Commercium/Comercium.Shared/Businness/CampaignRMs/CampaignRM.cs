using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.ProductRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.CampaignRMs
{
    public class CampaignRM
    {
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercentage { get; set; }

        public int BusinessProfileId { get; set; }
        public BusinessProfileRM BusinessProfile { get; set; }

        public IEnumerable<ProductRM> Products { get; set; }
    }

}
