using Commercium.Entity.Businness;
using Commercium.Entity.User.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.User
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public string UserId { get; set; }  // Favoriyi ekleyen kullanıcı
        public AppUser User { get; set; }   // Kullanıcı bilgisi

        public int? ProductId { get; set; }  // Favori ürün
        public Product Product { get; set; } // Ürün bilgisi

        public int? ServiceId { get; set; }  // Favori hizmet
        public Service Service { get; set; } // Hizmet bilgisi
    }


}
