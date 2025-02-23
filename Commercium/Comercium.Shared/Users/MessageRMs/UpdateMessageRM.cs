using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Users.MessageRMs
{
    public class UpdateMessageRM
    {
        [Required(ErrorMessage = "Mesaj ID gereklidir.")]
        public int MessageId { get; set; }

        [StringLength(2000, ErrorMessage = "Mesaj en fazla 2000 karakter olabilir.")]
        public string? Content { get; set; }

        public bool? IsRead { get; set; }
        public IFormFile? MediaFile { get; set; }
    }

}
