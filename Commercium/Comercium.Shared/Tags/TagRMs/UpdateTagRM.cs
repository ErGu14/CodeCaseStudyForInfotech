using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Tags.TagRMs
{
    public class UpdateTagRM
    {
        [Required(ErrorMessage = "Etiket ID gereklidir.")]
        public int TagId { get; set; }

        [StringLength(100, ErrorMessage = "Etiket adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; }

        public IEnumerable<int>? ProductIds { get; set; }
        public IEnumerable<int>? ServiceIds { get; set; }
        public IEnumerable<int>? BusinessProfileIds { get; set; }
    }

}
