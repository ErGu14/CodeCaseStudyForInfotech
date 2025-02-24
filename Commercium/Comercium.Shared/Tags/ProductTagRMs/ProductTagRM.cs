using Commercium.Shared.ProductRMs;
using Commercium.Shared.Tags.TagRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Tags.ProductTagRMs
{
    public class ProductTagRM
    {
        public int ProductId { get; set; }
        public ProductRM Product { get; set; }

        public int TagId { get; set; }
        public TagRM Tag { get; set; }
    }


}
