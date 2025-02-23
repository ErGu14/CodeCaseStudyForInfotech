using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.CategoryRMs
{
    public class CreateCategoryRM
    {
        [Required(ErrorMessage = "Kategori adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; }
    }

}
