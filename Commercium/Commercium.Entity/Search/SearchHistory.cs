using Commercium.Entity.User.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.Search
{
    public class SearchHistory
    {
        public int SearchHistoryId { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public string SearchQuery { get; set; }
        public DateTime SearchDate { get; set; }
    }

}
