using Commercium.Shared.Businness.CampaignRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.ReturnRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface ICampaignService
    {
        // Kampanyayı oluştur
        Task<ReturnRM<CampaignRM>> CreateCampaignAsync(CreateCampaignRM createCampaignRM);

        // Kampanyayı güncelle
        Task<ReturnRM<CampaignRM>> UpdateCampaignAsync(UpdateCampaignRM updateCampaignRM);

        // Kampanyayı sil
        Task<ReturnRM<string>> DeleteCampaignAsync(int campaignId);

        // Kampanyayı ID ile getir
        Task<ReturnRM<CampaignRM>> GetCampaignByIdAsync(int campaignId);

        // Tüm kampanyaları getir
        Task<ReturnRM<IEnumerable<CampaignRM>>> GetAllCampaignsAsync();

        // Kampanyaya ait ürünleri getir
        Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByCampaignIdAsync(int campaignId);

        // İşletme profili ID'sine göre kampanyaları getir
        Task<ReturnRM<IEnumerable<CampaignRM>>> GetCampaignsByBusinessProfileIdAsync(int businessProfileId);

        // Kampanyaların başlangıç ve bitiş tarihlerine göre filtrelenmesi
        Task<ReturnRM<IEnumerable<CampaignRM>>> GetCampaignsByDateRangeAsync(DateTime startDate, DateTime endDate);

        // Kampanyaya ürün eklemek ya da güncellemek
        Task<ReturnRM<string>> UpdateCampaignProductsAsync(int campaignId, IEnumerable<int> productIds);

    }

}
