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

        public string UserId { get; set; }
        public AppUserRM User { get; set; }

        public int? ProductId { get; set; }
        public ProductRM? Product { get; set; }

        public int? ServiceId { get; set; }
        public ServiceRM? Service { get; set; }
    }

}
