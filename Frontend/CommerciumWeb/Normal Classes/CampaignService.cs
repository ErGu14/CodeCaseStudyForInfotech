using CommerciumWeb.Bases;
using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using System.Text.Json;

namespace CommerciumWeb.Normal_Classes
{
    public class CampaignService : BaseService, ICampaignService
    {
        public CampaignService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<string>> CreateCampaignAsync(CampaignModel createCampaignModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("campaign/create", createCampaignModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> UpdateCampaignAsync(CampaignModel updateCampaignModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PutAsJsonAsync("campaign/update", updateCampaignModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> DeleteCampaignAsync(int campaignId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"campaign/delete/{campaignId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<CampaignModel>> GetCampaignByIdAsync(int campaignId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"campaign/{campaignId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<CampaignModel>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<CampaignModel> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<CampaignModel>>> GetAllCampaignsAsync()
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync("campaign/all");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<CampaignModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<CampaignModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByCampaignIdAsync(int campaignId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"campaign/{campaignId}/products");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ProductModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<CampaignModel>>> GetCampaignsByBusinessProfileIdAsync(int businessProfileId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"campaign/business/{businessProfileId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<CampaignModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<CampaignModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<CampaignModel>>> GetCampaignsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"campaign/date-range?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<CampaignModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<CampaignModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> UpdateCampaignProductsAsync(int campaignId, IEnumerable<int> productIds)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PutAsJsonAsync($"campaign/{campaignId}/update-products", productIds);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }
    }

}
