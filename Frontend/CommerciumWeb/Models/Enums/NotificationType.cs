using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Enums
{
    public enum NotificationType
    {
        ProductLike = 1, // Ürün beğenildi
        ProductComment = 2, // Ürün yorumu yapıldı
        CampaignUpdate = 3, // Kampanya güncellenmesi
        MessageReceived = 4, // Yeni mesaj alındı
        ProfileUpdate = 5, // Profil güncellemesi
        ProductClick = 6  // Ürün tıklandı
    }

}
