using CommerciumWeb.Bases;
using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using System.Text.Json;

namespace CommerciumWeb.Normal_Classes
{
    public class BusinessService : BaseService, IBusinessService
    {
        public BusinessService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<BusinessProfileModel>> GetBusinessByIdAsync(int businessProfileId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"business-profile/{businessProfileId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<BusinessProfileModel>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<BusinessProfileModel> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<BusinessProfileModel>>> GetAllBusinessesAsync()
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync("business-profile/all");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<BusinessProfileModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<BusinessProfileModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> CreateBusinessAsync(BusinessProfileModel createBusinessProfileModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("business-profile/create", createBusinessProfileModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> UpdateBusinessAsync(BusinessProfileModel updateBusinessProfileModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PutAsJsonAsync("business-profile/update", updateBusinessProfileModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> DeleteBusinessAsync(int businessProfileId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"business-profile/delete/{businessProfileId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> IncreaseBusinessLikeCountAsync(int businessProfileId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"business-profile/increase-like/{businessProfileId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> IncreaseBusinessClickCountAsync(int businessProfileId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"business-profile/increase-click/{businessProfileId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> IncreaseBusinessViewCountAsync(int businessProfileId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"business-profile/increase-view/{businessProfileId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> CustomizeBusinessProfileAsync(BusinessProfileCustomizationModel updateBusinessProfileCustomizationModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("business-profile/customize-profile", updateBusinessProfileCustomizationModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> AddBusinessTagAsync(BusinessProfileCustomizationModel createBusinessProfileTagModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("business-profile/add-business-tag", createBusinessProfileTagModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> RemoveBusinessTagAsync(BusinessProfileCustomizationModel updateBusinessProfileTagModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("business-profile/remove-business-tag", updateBusinessProfileTagModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<BusinessServiceModel>> GetServiceByIdAsync(int serviceId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"business-profile/service/{serviceId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<BusinessServiceModel>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<BusinessServiceModel> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<BusinessServiceModel>>> GetAllServicesAsync()
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync("business-profile/services");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<BusinessServiceModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<BusinessServiceModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<BusinessServiceModel>>> GetServicesByBusinessAsync(int businessProfileId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"business-profile/business/{businessProfileId}/services");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<BusinessServiceModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<BusinessServiceModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> CreateServiceAsync(BusinessServiceModel createServiceModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("business-profile/service/create", createServiceModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> UpdateServiceAsync(BusinessServiceModel updateServiceModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PutAsJsonAsync("business-profile/service/update", updateServiceModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> DeleteServiceAsync(int serviceId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"business-profile/service/delete/{serviceId}");
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
