using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.ProductRMs
{
    public class UpdateProductRM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public IFormFile imgUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BusinessProfileId { get; set; }
        public int[] ProductCategoryIds { get; set; }
        public int[] ProductTagIds { get; set; }
    }
}
