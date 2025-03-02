using CommerciumWeb.Bases;
using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using System.Text.Json;

namespace CommerciumWeb.Normal_Classes
{
    public class FavoriteService : BaseService, IFavoriteService
    {
        public FavoriteService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<string>> AddFavoriteProductAsync(FavoriteModel createFavoriteModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("favorite/add-product", createFavoriteModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> RemoveFavoriteProductAsync(FavoriteModel updateFavoriteModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("favorite/remove-product", updateFavoriteModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> AddFavoriteServiceAsync(FavoriteModel createFavoriteModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("favorite/add-service", createFavoriteModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> RemoveFavoriteServiceAsync(FavoriteModel updateFavoriteModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("favorite/remove-service", updateFavoriteModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ProductModel>>> GetUserFavoriteProductsAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"favorite/user/{userId}/products");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ProductModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<BusinessServiceModel>>> GetUserFavoriteServicesAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"favorite/user/{userId}/services");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<BusinessServiceModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<BusinessServiceModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<FavoriteModel>>> GetUserFavoritesAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"favorite/user/{userId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<FavoriteModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<FavoriteModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<int>> GetFavoriteCountForProductAsync(int productId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"favorite/product/{productId}/count");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<int>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<int> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<int>> GetFavoriteCountForServiceAsync(int serviceId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"favorite/service/{serviceId}/count");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<int>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<int> { Errors = new List<string> { ex.Message } };
            }
        }
    }

}
