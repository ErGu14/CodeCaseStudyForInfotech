using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.CampaignRMs
{
    public class UpdateCampaignRM
    {
        [Required(ErrorMessage = "Kampanya ID gereklidir.")]
        public int CampaignId { get; set; }

        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        public string? Title { get; set; }

        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Range(0, 100, ErrorMessage = "İndirim yüzdesi 0 ile 100 arasında olmalıdır.")]
        public decimal? DiscountPercentage { get; set; }

        public IEnumerable<int>? ProductIds { get; set; }  // Kampanyaya dahil edilen ürünlerin ID'leri
    }



}
