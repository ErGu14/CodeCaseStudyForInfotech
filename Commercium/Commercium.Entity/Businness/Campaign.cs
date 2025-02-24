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
        public DateTime StartDate { get; set; }  // Kampanya başlangıç tarihi
        public DateTime EndDate { get; set; }    // Kampanya bitiş tarihi
        public decimal DiscountPercentage { get; set; }  // İndirim yüzdesi

        // Kampanya ile ilişkilendirilen ürünler
        public ICollection<Product> Products { get; set; }

        // İlişkili işletme profili
        public int BusinessProfileId { get; set; }
        public BusinessProfile BusinessProfile { get; set; }

        // Kampanya performansı
        public int ClickCount { get; set; }  // Tıklama sayısı
        public int LikeCount { get; set; }   // Beğeni sayısı
        public int ViewCount { get; set; }   // Görüntülenme sayısı
    }




}
