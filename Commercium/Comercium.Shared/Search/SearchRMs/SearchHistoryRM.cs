using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Search.SearchRMs
{
    public class SearchHistoryRM
    {
        public int SearchHistoryId { get; set; }
        public string UserId { get; set; }
        public AppUserRM User { get; set; }
        public string SearchQuery { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
