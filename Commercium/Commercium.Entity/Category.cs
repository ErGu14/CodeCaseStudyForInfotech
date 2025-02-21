using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } 

        public ICollection<ProductCategory> ProductCategories { get; set; }  // Ürünlerle ilişkisi
    }

}
