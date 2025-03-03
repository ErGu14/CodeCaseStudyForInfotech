using Commercium.Entity.User.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.User
{
    public class UserFollow
    {
        public string FollowerId { get; set; }  
        public AppUser Follower { get; set; }   

        public string FollowedId { get; set; }  
        public AppUser Followed { get; set; }   
    }



}
