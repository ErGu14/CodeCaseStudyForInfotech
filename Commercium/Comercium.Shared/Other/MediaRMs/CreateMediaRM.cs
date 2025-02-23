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
    public class CreateMediaRM
    {
        [Required(ErrorMessage = "Dosya yüklenmesi gereklidir.")]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Medya türü gereklidir.")]
        public MediaType MediaType { get; set; }

        public int? ProductId { get; set; }
        public int? ServiceId { get; set; }
        public int? MessageId { get; set; }
    }

}
