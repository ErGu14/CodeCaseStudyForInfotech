using Commercium.Entity.Tags;
using Commercium.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.Businness
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int ClickCount { get; set; }  
        public int LikeCount { get; set; }  

        public BusinessProfile BusinessProfile { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public int? FavoriteId { get; set; }
        public Favorite? Favorite { get; set; }
       
        public ICollection<ServiceTag> ServiceTags { get; set; }
        public int BusinessProfileId { get; set; }
    }

}
