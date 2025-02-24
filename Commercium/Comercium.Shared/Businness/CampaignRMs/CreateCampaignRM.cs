using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Shared.Businness.CampaignRMs
{
    public class CreateCampaignRM
    {
        [Required(ErrorMessage = "Kampanya başlığı gereklidir.")]
        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi gereklidir.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi gereklidir.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "İndirim yüzdesi gereklidir.")]
        [Range(0, 100, ErrorMessage = "İndirim yüzdesi 0 ile 100 arasında olmalıdır.")]
        public decimal DiscountPercentage { get; set; }

        [Required(ErrorMessage = "İşletme profili ID gereklidir.")]
        public int BusinessProfileId { get; set; }

        [Required(ErrorMessage = "Ürün ID'leri gereklidir.")]
        public IEnumerable<int> ProductIds { get; set; }  // Kampanyaya dahil edilen ürünlerin ID'leri
    }



}
