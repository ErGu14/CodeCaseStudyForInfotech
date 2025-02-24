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
        public string FollowerId { get; set; }  // Takip eden kullanıcı ID'si
        public AppUserRM Follower { get; set; } // Takip eden kullanıcı bilgisi

        public string FollowedId { get; set; }  // Takip edilen kullanıcı ID'si
        public AppUserRM Followed { get; set; } // Takip edilen kullanıcı bilgisi
    }

}
