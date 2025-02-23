using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.BusinessProfileTagRMs
{
    public class CreateBusinessProfileTagRM
    {
        [Required(ErrorMessage = "İşletme profili ID gereklidir.")]
        public int BusinessProfileId { get; set; }

        [Required(ErrorMessage = "Etiket ID gereklidir.")]
        public int TagId { get; set; }
    }

}
