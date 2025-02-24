using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.FavoriteRMs
{
    public class UpdateFavoriteRM
    {
        [Required(ErrorMessage = "Favori ID gereklidir.")]
        public int FavoriteId { get; set; }

        public int? ProductId { get; set; }  // Favori ürün
        public int? ServiceId { get; set; }  // Favori hizmet

        [Required(ErrorMessage = "Kullanıcı ID gereklidir.")]
        public string UserId { get; set; }  // Favoriyi ekleyen kullanıcının ID'si
    }


}
