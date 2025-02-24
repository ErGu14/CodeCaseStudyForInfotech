using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.ProductCategoryRMs;
using Commercium.Shared.Users.ReviewRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.ProductRMs
{
    public class ProductRM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ClickCount { get; set; }
        public int ViewCount { get; set; }

        public int LikeCount { get; set; }
        public BusinessProfileRM BusinessProfile { get; set; }
        public IEnumerable<ReviewRM>? Reviews { get; set; }
        public IEnumerable<ProductCategoryRM> ProductCategories { get; set; }
        public IEnumerable<ProductRM> ProductTags { get; set; }
    }
}
