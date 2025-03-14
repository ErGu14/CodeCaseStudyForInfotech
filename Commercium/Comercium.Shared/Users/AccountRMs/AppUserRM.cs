﻿using Commercium.Shared.Businness.BusinessProfileRMs;
using Commercium.Shared.Enums;
using Commercium.Shared.Users.UserFollowRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.AccountRMs
{
    public class AppUserRM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }  
        public UserStatus Status { get; set; }
        public UserRole Role { get; set; }
        public IEnumerable<BusinessProfileRM> BusinessProfiles { get; set; }
        public IEnumerable<UserFollowRM> Follows { get; set; }
        public IEnumerable<UserFollowRM> FollowedBy { get; set; }
    }

}
