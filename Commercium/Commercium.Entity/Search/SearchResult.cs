using Commercium.Entity.Businness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.Search
{
    public class SearchResult
    {
        public int SearchResultId { get; set; }

        public string SearchQuery { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public int? ServiceId { get; set; }
        public Service Service { get; set; }

        public int BusinessProfileId { get; set; }
        public BusinessProfile BusinessProfile { get; set; }

        public DateTime SearchDate { get; set; }
    }

}
