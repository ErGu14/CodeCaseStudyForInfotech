using AutoMapper;
using Commercium.Data.Interfaces;
using Commercium.Entity.Businness;
using Commercium.Entity;
using Commercium.Service.Interfaces;
using Commercium.Shared.Businness.CampaignRMs;
using Commercium.Shared.ProductRMs;
using Commercium.Shared.ReturnRMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Classes
{
    public class CampaignService : ICampaignService
    {
        private readonly IGenericManager<Campaign> _campaignManager;
        private readonly IGenericManager<Product> _productManager;
        private readonly ITransactionManager _transactionManager;
        private readonly IMapper _mapper;

        public CampaignService(IGenericManager<Campaign> campaignManager,
                               IGenericManager<Product> productManager,
                               ITransactionManager transactionManager,
                               IMapper mapper)
        {
            _campaignManager = campaignManager;
            _productManager = productManager;
            _transactionManager = transactionManager;
            _mapper = mapper;
        }

        // Kampanya oluşturma
        public async Task<ReturnRM<CampaignRM>> CreateCampaignAsync(CreateCampaignRM createCampaignRM)
        {
            var campaign = new Campaign
            {
                Title = createCampaignRM.Title,
                Description = createCampaignRM.Description,
                StartDate = createCampaignRM.StartDate,
                EndDate = createCampaignRM.EndDate,
                DiscountPercentage = createCampaignRM.DiscountPercentage,
                BusinessProfileId = createCampaignRM.BusinessProfileId
            };

            // Ürünleri kampanyaya ekliyoruz
            var products = await _productManager.GetByIdsAsync(createCampaignRM.ProductIds);
            campaign.Products = products.ToList();

            try
            {
                // Kampanyayı veritabanına ekliyoruz
                await _transactionManager.GetManager<Campaign>().AddAsync(campaign);
                await _transactionManager.SaveAsync();  // Veritabanına kaydet
            }
            catch (Exception ex)
            {
                return ReturnRM<CampaignRM>.Fail(ex.Message, 500);
            }

            return ReturnRM<CampaignRM>.Success(_mapper.Map<CampaignRM>(campaign), 200);
        }

        // Kampanya güncelleme
        public async Task<ReturnRM<CampaignRM>> UpdateCampaignAsync(UpdateCampaignRM updateCampaignRM)
        {
            var campaign = await _campaignManager.GetByIdAsync(updateCampaignRM.CampaignId);
            if (campaign == null)
            {
                return ReturnRM<CampaignRM>.Fail("Kampanya bulunamadı.", 404);
            }

            campaign.Title = updateCampaignRM.Title ?? campaign.Title;
            campaign.Description = updateCampaignRM.Description ?? campaign.Description;
            campaign.StartDate = updateCampaignRM.StartDate ?? campaign.StartDate;
            campaign.EndDate = updateCampaignRM.EndDate ?? campaign.EndDate;
            campaign.DiscountPercentage = updateCampaignRM.DiscountPercentage ?? campaign.DiscountPercentage;

            // Ürünleri güncelliyoruz
            var products = await _productManager.GetByIdsAsync(updateCampaignRM.ProductIds);
            campaign.Products = products.ToList();

            try
            {
                 _transactionManager.GetManager<Campaign>().Update(campaign);
                await _transactionManager.SaveAsync();  
            }
            catch (Exception ex)
            {
                return ReturnRM<CampaignRM>.Fail(ex.Message, 500);
            }

            return ReturnRM<CampaignRM>.Success(_mapper.Map<CampaignRM>(campaign), 200);
        }

        // Kampanyayı ID ile getir
        public async Task<ReturnRM<CampaignRM>> GetCampaignByIdAsync(int campaignId)
        {
            var campaign = await _campaignManager.GetByIdAsync(campaignId);
            if (campaign == null)
            {
                return ReturnRM<CampaignRM>.Fail("Kampanya bulunamadı.", 404);
            }

            return ReturnRM<CampaignRM>.Success(_mapper.Map<CampaignRM>(campaign), 200);
        }

        // Tüm kampanyaları getir
        public async Task<ReturnRM<IEnumerable<CampaignRM>>> GetAllCampaignsAsync()
        {
            var campaigns = await _campaignManager.GetAllAsync();
            return ReturnRM<IEnumerable<CampaignRM>>.Success(campaigns.Select(c => _mapper.Map<CampaignRM>(c)), 200);
        }

        // Kampanyaya ait ürünleri getir
        public async Task<ReturnRM<IEnumerable<ProductRM>>> GetProductsByCampaignIdAsync(int campaignId)
        {
            var campaign = await _campaignManager.GetByIdAsync(campaignId);
            if (campaign == null)
            {
                return ReturnRM<IEnumerable<ProductRM>>.Fail("Kampanya bulunamadı.", 404);
            }

            var products = campaign.Products;
            return ReturnRM<IEnumerable<ProductRM>>.Success(products.Select(p => _mapper.Map<ProductRM>(p)), 200);
        }

        // İşletme profili ID'sine göre kampanyaları getir
        public async Task<ReturnRM<IEnumerable<CampaignRM>>> GetCampaignsByBusinessProfileIdAsync(int businessProfileId)
        {
            var campaigns = await _campaignManager.GetAllAsync(c => c.BusinessProfileId == businessProfileId);
            return ReturnRM<IEnumerable<CampaignRM>>.Success(campaigns.Select(c => _mapper.Map<CampaignRM>(c)), 200);
        }

        // Kampanyaların başlangıç ve bitiş tarihlerine göre filtrelenmesi
        public async Task<ReturnRM<IEnumerable<CampaignRM>>> GetCampaignsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var campaigns = await _campaignManager.GetAllAsync(c => c.StartDate >= startDate && c.EndDate <= endDate);
            return ReturnRM<IEnumerable<CampaignRM>>.Success(campaigns.Select(c => _mapper.Map<CampaignRM>(c)), 200);
        }

        // Kampanyaya ürün eklemek ya da güncellemek
        public async Task<ReturnRM<string>> UpdateCampaignProductsAsync(int campaignId, IEnumerable<int> productIds)
        {
            var campaign = await _campaignManager.GetByIdAsync(campaignId);
            if (campaign == null)
            {
                return ReturnRM<string>.Fail("Kampanya bulunamadı.", 404);
            }

            // Ürünleri kampanyaya eklemek için
            var products = await _productManager.GetByIdsAsync(productIds);
            campaign.Products = products.ToList(); 

            try
            {
                // Kampanyayı güncelliyoruz
                 _transactionManager.GetManager<Campaign>().Update(campaign);
                await _transactionManager.SaveAsync();  
            }
            catch (Exception ex)
            {
                return ReturnRM<string>.Fail(ex.Message, 500);  
            }

            return ReturnRM<string>.Success("Kampanya ürünleri başarıyla güncellendi.", 200); 
        }

        public async Task<ReturnRM<string>> DeleteCampaignAsync(int campaignId)
        {
            var campaign = await _campaignManager.GetByIdAsync(campaignId);
            if (campaign == null)
            {
                return ReturnRM<string>.Fail("Kampanya bulunamadı.", 404);
            }

            try
            {
                // Kampanyayı silme
                _campaignManager.Delete(campaign);  
                await _transactionManager.SaveAsync();  
            }
            catch (Exception ex)
            {
                return ReturnRM<string>.Fail(ex.Message, 500);  
            }

            return ReturnRM<string>.Success("Kampanya başarıyla silindi.", 200);  
        }

    }
}
