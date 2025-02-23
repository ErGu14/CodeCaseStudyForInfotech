using Commercium.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.NotificationRMs
{
    public class CreateNotificationRM
    {
        public string UserId { get; set; } // Bildirimi alacak kullanıcı
        public NotificationType NotificationType { get; set; }
        public string Message { get; set; }
        public int? ProductId { get; set; }
        public int? ServiceId { get; set; }
        public int? BusinessProfileId { get; set; }
    }
}
