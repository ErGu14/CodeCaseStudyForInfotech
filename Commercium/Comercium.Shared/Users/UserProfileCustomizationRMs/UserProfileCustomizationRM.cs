using Commercium.Shared.Users.AccountRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.UserProfileCustomizationRMs
{
    public class UserProfileCustomizationRM
    {
        public int UserProfileCustomizationId { get; set; }
        public string CustomProfileImage { get; set; }
        public string CustomBackgroundImage { get; set; }
        public string CustomDescription { get; set; }
        public string UserId { get; set; }
        public AppUserRM User { get; set; }
    }
}
