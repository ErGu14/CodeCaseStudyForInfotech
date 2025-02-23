﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.UserProfileCustomizationRMs
{
    public class UpdateUserProfileCustomizationRM
    {
        public int UserProfileCustomizationId { get; set; }
        public IFormFile CustomProfileImage { get; set; }
        public IFormFile CustomBackgroundImage { get; set; }
        public string CustomDescription { get; set; }
    }
}
