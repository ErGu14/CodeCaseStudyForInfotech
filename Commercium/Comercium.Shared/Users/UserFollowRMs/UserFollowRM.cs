using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.UserFollowRMs
{
    public class UserFollowRM
    {
        public string FollowerId { get; set; }
        public AppUserRM Follower { get; set; }
        public string FollowedId { get; set; }
        public AppUserRM Followed { get; set; }
    }
}
