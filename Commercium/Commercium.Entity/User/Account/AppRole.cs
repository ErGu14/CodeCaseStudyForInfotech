﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.User.Account
{
    public class AppRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
