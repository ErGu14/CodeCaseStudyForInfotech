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
    public class UpdateBusinessProfileRM
    {
        [Required(ErrorMessage = "İşletme profili ID gereklidir.")]
        public int BusinessProfileId { get; set; }

        [StringLength(100, ErrorMessage = "İşletme adı en fazla 100 karakter olabilir.")]
        public string? BusinessName { get; set; }

        [StringLength(1000, ErrorMessage = "İşletme açıklaması en fazla 1000 karakter olabilir.")]
        public string? BusinessDescription { get; set; }

        public string? ContactInfo { get; set; }
        public string? Location { get; set; }

        public IEnumerable<ProductRM> Products { get; set; }
        public IEnumerable<ServiceRM> Services { get; set; }
        public IEnumerable<BusinessProfileTagRM> BusinessProfileTags { get; set; }
    }
}
