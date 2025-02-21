using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int ClickCount { get; set; }  // Tıklanma sayısı
        public int LikeCount { get; set; }   // Beğenilme sayısı

        public BusinessProfile BusinessProfile { get; set; }
        public ICollection<Review> Reviews { get; set; }

        // Etiketler
        public ICollection<ServiceTag> ServiceTags { get; set; }
    }

}
