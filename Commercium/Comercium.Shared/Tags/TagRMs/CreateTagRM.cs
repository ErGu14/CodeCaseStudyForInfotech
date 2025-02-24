using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Tags.TagRMs
{
    public class CreateTagRM
    {
        [Required(ErrorMessage = "Etiket adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Etiket adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; }

        public IEnumerable<int> ProductIds { get; set; } // Tag ile ilişkilendirilen ürünler
        public IEnumerable<int> ServiceIds { get; set; } // Tag ile ilişkilendirilen hizmetler
        public IEnumerable<int> BusinessProfileIds { get; set; } // Tag ile ilişkilendirilen işletmeler
    }

}
