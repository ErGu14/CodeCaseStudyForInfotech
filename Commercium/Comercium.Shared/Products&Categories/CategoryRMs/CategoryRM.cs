using Commercium.Shared.ProductCategoryRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.CategoryRMs
{
    public class CategoryRM
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public IEnumerable<ProductCategoryRM> ProductCategories { get; set; }
    }

}
