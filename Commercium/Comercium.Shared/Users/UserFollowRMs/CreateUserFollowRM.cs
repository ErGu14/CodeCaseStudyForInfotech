using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.UserFollowRMs
{
    public class CreateUserFollowRM
    {
        [Required(ErrorMessage = "Takip eden kullanıcı ID gereklidir.")]
        public string FollowerId { get; set; }  // Takip eden kullanıcı ID'si

        [Required(ErrorMessage = "Takip edilen kullanıcı ID gereklidir.")]
        public string FollowedId { get; set; }  // Takip edilen kullanıcı ID'si
    }

}
