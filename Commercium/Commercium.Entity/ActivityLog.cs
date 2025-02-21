using Commercium.Entity.Account;
using Commercium.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity
{
    public class ActivityLog
    {
        public int ActivityLogId { get; set; }
        public ActivityType ActivityType { get; set; }  // Tıklama, Beğenme, Görüntülenme, vb.
        public DateTime ActivityDate { get; set; }
        public string Details { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public AppUser User { get; set; }
        public string EntityName { get; set; }  // Hangi ürün veya hizmet
        public Product? Product { get; set; }
        public Service? Service { get; set; }

    }

}
