using Commercium.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.AccountRMs
{
    public class ChangeUserRoleRM
    {
        [Required(ErrorMessage = "Kullanıcı kimliği gereklidir.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Yeni rol gereklidir.")]
        public UserRole NewRole { get; set; }
    }
}
