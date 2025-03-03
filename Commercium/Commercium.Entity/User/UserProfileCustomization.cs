﻿using Commercium.Entity.User.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.User
{
    public class UserProfileCustomization
    {
        public int UserProfileCustomizationId { get; set; }
        public string CustomProfileImage { get; set; }  
        public string CustomBackgroundImage { get; set; }  
        public string CustomDescription { get; set; }  

  
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }


}
