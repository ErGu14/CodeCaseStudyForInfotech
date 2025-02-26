using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.Enums;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.ActivityLogRMs
{
    public class ActivityLogRM
    {
        public int ActivityLogId { get; set; }
        public ActivityType ActivityType { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Details { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; } // EntityType'ı string yapabiliriz çünkü genellikle enum'dan gelen değeri yazdırmak isteriz
        public string UserId { get; set; }
        public AppUserRM User { get; set; }
        public string EntityName { get; set; }
        public int? ProductId { get; set; }
        public ProductRM Product { get; set; }
        public int? ServiceId { get; set; }
        public ServiceRM Service { get; set; }
    }
    }

