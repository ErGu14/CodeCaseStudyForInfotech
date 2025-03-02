using CommerciumWeb.Bases;
using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using System.Text.Json;

namespace CommerciumWeb.Normal_Classes
{
    public class TagService : BaseService, ITagService
    {
        public TagService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<TagModel>> GetTagByIdAsync(int tagId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"api/tag/{tagId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<TagModel>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<TagModel> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<TagModel>>> GetAllTagsAsync()
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync("api/tag/all");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<TagModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<TagModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> CreateTagAsync(TagModel createTagModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("api/tag/create", createTagModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> UpdateTagAsync(TagModel updateTagModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PutAsJsonAsync("api/tag/update", updateTagModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> DeleteTagAsync(int tagId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"api/tag/delete/{tagId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByTagAsync(int tagId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"api/tag/{tagId}/products");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ProductModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<BusinessServiceModel>>> GetServicesByTagAsync(int tagId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"api/tag/{tagId}/services");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<BusinessServiceModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<BusinessServiceModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<BusinessProfileModel>>> GetBusinessesByTagAsync(int tagId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"api/tag/{tagId}/businesses");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<BusinessProfileModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<BusinessProfileModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<TagModel>>> GetTopTagsAsync(int count)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"api/tag/top?count={count}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<TagModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<TagModel>> { Errors = new List<string> { ex.Message } };
            }
        }
    }
}
