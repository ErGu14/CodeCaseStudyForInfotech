using CommerciumWeb.Models;

namespace CommerciumWeb.Interfaces
{
    public interface ICampaignService
    {
        Task<ReturnModel<string>> CreateCampaignAsync(CampaignModel createCampaignModel);
        Task<ReturnModel<string>> UpdateCampaignAsync(CampaignModel updateCampaignModel);
        Task<ReturnModel<string>> DeleteCampaignAsync(int campaignId);
        Task<ReturnModel<CampaignModel>> GetCampaignByIdAsync(int campaignId);
        Task<ReturnModel<IEnumerable<CampaignModel>>> GetAllCampaignsAsync();
        Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByCampaignIdAsync(int campaignId);
        Task<ReturnModel<IEnumerable<CampaignModel>>> GetCampaignsByBusinessProfileIdAsync(int businessProfileId);
        Task<ReturnModel<IEnumerable<CampaignModel>>> GetCampaignsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ReturnModel<string>> UpdateCampaignProductsAsync(int campaignId, IEnumerable<int> productIds);
    }

}
