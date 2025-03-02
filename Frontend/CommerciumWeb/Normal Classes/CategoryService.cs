using CommerciumWeb.Bases;
using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using System.Text.Json;

namespace CommerciumWeb.Normal_Classes
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<CategoryModel>> GetCategoryByIdAsync(int categoryId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"category/{categoryId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<CategoryModel>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<CategoryModel> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<CategoryModel>>> GetAllCategoriesAsync()
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync("category/all");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<CategoryModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<CategoryModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> CreateCategoryAsync(CategoryModel createCategoryModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("category/create", createCategoryModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> UpdateCategoryAsync(CategoryModel updateCategoryModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PutAsJsonAsync("category/update", updateCategoryModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> DeleteCategoryAsync(int categoryId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"category/delete/{categoryId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByCategoryAsync(int categoryId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"category/{categoryId}/products");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ProductModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<int>> GetProductCountByCategoryAsync(int categoryId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"category/{categoryId}/product-count");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<int>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<int> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<CategoryModel>>> GetTopCategoriesAsync(int count)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"category/top?count={count}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<CategoryModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<CategoryModel>> { Errors = new List<string> { ex.Message } };
            }
        }
    }

}
