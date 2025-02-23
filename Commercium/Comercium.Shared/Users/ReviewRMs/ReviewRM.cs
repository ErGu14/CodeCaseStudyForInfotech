using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.ReviewRMs
{
    public class ReviewRM
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public int? ProductId { get; set; }
        public ProductRM Product { get; set; }
        public int? ServiceId { get; set; }
        public ServiceRM Service { get; set; }
        public string UserId { get; set; }
        public AppUserRM User { get; set; }
    }
}
