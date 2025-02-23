using Commercium.Entity.Businness;
using Commercium.Entity.User.Account;
using Commercium.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.User
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public string UserId { get; set; }  // Hangi kullanıcıya bildirim gidecek
        public AppUser User { get; set; }

        public NotificationType NotificationType { get; set; }  // Bildirim türü (enum'dan)
        public string Message { get; set; }  // Bildirim mesajı
        public DateTime DateCreated { get; set; }  // Bildirimin oluşturulma tarihi
        public bool IsRead { get; set; }  // Bildirim okundu mu?

        public int? ProductId { get; set; }  // Ürünle ilgili bildirim varsa
        public Product Product { get; set; }

        public int? ServiceId { get; set; }  // Hizmetle ilgili bildirim varsa
        public Service Service { get; set; }

        public int? BusinessProfileId { get; set; }  // İşletme profili ile ilgili bildirim
        public BusinessProfile BusinessProfile { get; set; }
    }

}
