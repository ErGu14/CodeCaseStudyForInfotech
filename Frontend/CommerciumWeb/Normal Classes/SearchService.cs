using CommerciumWeb.Bases;
using CommerciumWeb.Models.SearchModels.Commercium.MVC.Models;
using CommerciumWeb.Models.SearchModels;
using CommerciumWeb.Models;
using System.Text.Json;
using CommerciumWeb.Interfaces;

namespace CommerciumWeb.Normal_Classes
{
    public class SearchService : BaseService, ISearchService
    {
        public SearchService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<IEnumerable<SearchResultModel>>> SearchAsync(string query)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"search/search?query={query}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<SearchResultModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<SearchResultModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> SaveSearchHistoryAsync(string userId, string query)
        {
            try
            {
                var client = GetHttpClient();
                var requestBody = new { query };
                var response = await client.PostAsJsonAsync($"search/save-history?userId={userId}", requestBody);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<SearchHistoryModel>>> GetUserSearchHistoryAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"search/user/{userId}/history");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<SearchHistoryModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<SearchHistoryModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<SearchResultModel>>> SearchByTagAsync(int tagId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"search/search-by-tag/{tagId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<SearchResultModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<SearchResultModel>> { Errors = new List<string> { ex.Message } };
            }
        }
    }
}
