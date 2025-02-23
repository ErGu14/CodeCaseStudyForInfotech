using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.FavoriteRMs
{
    public class CreateFavoriteRM
    {
        [Required(ErrorMessage = "Kullanıcı ID gereklidir.")]
        public string UserId { get; set; }

        public int? ProductId { get; set; }
        public int? ServiceId { get; set; }
    }

}
