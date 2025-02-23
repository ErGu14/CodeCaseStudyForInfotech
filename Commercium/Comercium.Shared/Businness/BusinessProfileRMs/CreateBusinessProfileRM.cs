using Commercium.Shared.Businness.BusinessProfileTagRMs;
using Commercium.Shared.Businness.ServiceRMs;
using Commercium.Shared.ProductRMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.BusinessProfileRMs
{
    public class CreateBusinessProfileRM
    {
        [Required(ErrorMessage = "İşletme adı gereklidir.")]
        [StringLength(100, ErrorMessage = "İşletme adı en fazla 100 karakter olabilir.")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "İşletme açıklaması gereklidir.")]
        [StringLength(1000, ErrorMessage = "İşletme açıklaması en fazla 1000 karakter olabilir.")]
        public string BusinessDescription { get; set; }

        [Required(ErrorMessage = "İletişim bilgisi gereklidir.")]
        public string ContactInfo { get; set; }

        [Required(ErrorMessage = "Konum bilgisi gereklidir.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "İşletme sahibinin ID'si gereklidir.")]
        public string OwnerId { get; set; }

        public IEnumerable<ProductRM> Products { get; set; } = new List<ProductRM>();
        public IEnumerable<ServiceRM> Services { get; set; } = new List<ServiceRM>();
        public IEnumerable<BusinessProfileTagRM> BusinessProfileTags { get; set; } = new List<BusinessProfileTagRM>();

        public int ClickCount { get; set; } = 0;
        public int LikeCount { get; set; } = 0;
    }
}
