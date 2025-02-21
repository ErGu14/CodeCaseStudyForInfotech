using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercentage { get; set; }

        public BusinessProfile BusinessProfile { get; set; }
        public ICollection<Product> Products { get; set; }
    }

}
