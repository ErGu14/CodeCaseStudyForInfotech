using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.ProductRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Search.SearchRMs
{
    public class SearchResultRM
    {
        public int SearchResultId { get; set; }
        public string SearchQuery { get; set; }
        public int? ProductId { get; set; }
        public ProductRM Product { get; set; }
        public int? ServiceId { get; set; }
        public ServiceRM Service { get; set; }
        public int? BusinessProfileId { get; set; }
        public BusinessProfileRM BusinessProfile { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
