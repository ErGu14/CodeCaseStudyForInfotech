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

        public int? ProductId { get; set; }
        public int? ServiceId { get; set; }
    }

}
