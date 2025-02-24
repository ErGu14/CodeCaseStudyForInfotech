using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.FavoriteRMs
{
    public class FavoriteRM
    {
        public int FavoriteId { get; set; }
        public string UserId { get; set; } // Favori ekleyen kullanıcı ID'si
        public AppUserRM User { get; set; } // Kullanıcı bilgisi

        public int? ProductId { get; set; }  // Favori ürün
        public ProductRM Product { get; set; } // Ürün bilgisi

        public int? ServiceId { get; set; }  // Favori hizmet
        public ServiceRM Service { get; set; } // Hizmet bilgisi
    }


}
