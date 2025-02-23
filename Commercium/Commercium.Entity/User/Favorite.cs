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

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }

}
