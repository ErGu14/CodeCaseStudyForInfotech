using Commercium.Entity.Businness;
using Commercium.Shared.Enums;
using Commercium.Shared.Other.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Entity.User.Account
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }

        public ICollection<BusinessProfile>? BusinessProfiles { get; set; }
        public ICollection<UserFollow> Follows { get; set; }
        public ICollection<UserFollow> FollowedBy { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

}
