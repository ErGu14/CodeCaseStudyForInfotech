﻿using Commercium.Entity.User.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.User
{
    public class UserFollow
    {
        public string FollowerId { get; set; }  // Takip eden kullanıcı ID'si
        public AppUser Follower { get; set; }   // Takip eden kullanıcı bilgisi

        public string FollowedId { get; set; }  // Takip edilen kullanıcı ID'si
        public AppUser Followed { get; set; }   // Takip edilen kullanıcı bilgisi
    }



}
