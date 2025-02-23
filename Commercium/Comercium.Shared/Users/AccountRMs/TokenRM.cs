using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.AccountRMs
{
    public class TokenRM
    {
        public string AccessToken { get; set; }//JWT
        public DateTime ExpirationDate { get; set; }//JWT ömrü
    }
}
