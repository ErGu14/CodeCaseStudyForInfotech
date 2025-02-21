using Commercium.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.Account
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Takip eden kullanıcıları tutacak koleksiyon
        public ICollection<UserFollow> Follows { get; set; }

        // Takip edilen kullanıcıları tutacak koleksiyon
        public ICollection<UserFollow> FollowedBy { get; set; }
    }

}
