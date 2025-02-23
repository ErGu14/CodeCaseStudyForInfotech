using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.ProductRMs
{
    public class CreateProductRM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ClickCount { get; set; } = 0;
        public int LikeCount { get; set; } = 0;
        public int BusinessProfileId { get; set; }
        public int[] ProductCategoryIds { get; set; }
        public int[] ProductTagIds { get; set; }
    }
}
