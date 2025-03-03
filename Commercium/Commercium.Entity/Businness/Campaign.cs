using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.Businness
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }    
        public decimal DiscountPercentage { get; set; }  // İndirim yüzdesi

      
        public ICollection<Product> Products { get; set; }

       
        public int BusinessProfileId { get; set; }
        public BusinessProfile BusinessProfile { get; set; }

   
        public int ClickCount { get; set; }  
        public int LikeCount { get; set; }   
        public int ViewCount { get; set; }   
    }




}
