using Commercium.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Other.MediaRMs
{
    public class UpdateMediaRM
    {
        [Required(ErrorMessage = "Medya ID gereklidir.")]
        public int MediaId { get; set; }

        public IFormFile? File { get; set; }
        public MediaType? MediaType { get; set; }

        public int? ProductId { get; set; }
        public int? ServiceId { get; set; }
        public int? MessageId { get; set; }
    }

}
