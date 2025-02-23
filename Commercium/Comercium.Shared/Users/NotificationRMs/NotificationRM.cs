using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.Enums;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.NotificationRMs
{
    public class NotificationRM
    {
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        public AppUserRM User { get; set; } // Kullanıcı navigasyonu
        public NotificationType NotificationType { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsRead { get; set; }
        public int? ProductId { get; set; }
        public ProductRM Product { get; set; } // Ürün navigasyonu
        public int? ServiceId { get; set; }
        public ServiceRM Service { get; set; } // Hizmet navigasyonu
        public int? BusinessProfileId { get; set; }
        public BusinessProfileRM BusinessProfile { get; set; } // İşletme navigasyonu
    }
}
