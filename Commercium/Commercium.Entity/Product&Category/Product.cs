using Commercium.Entity.Businness;
using Commercium.Entity.Tags;
using Commercium.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity
{
    public class Product
    {
        public int ProductId { get; set; }

        public string imgUrl { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        
        public int ClickCount { get; set; } 
        public int LikeCount { get; set; }  

        public BusinessProfile BusinessProfile { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }  
        public int ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BusinessProfileId { get; set; }

        public int? FavoriteId { get; set; }
        public Favorite? Favorite { get; set; }
    }



}
