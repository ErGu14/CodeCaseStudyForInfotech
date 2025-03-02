using CommerciumWeb.Bases;
using CommerciumWeb.Models.ProductModels;
using CommerciumWeb.Models;
using System.Text.Json;
using CommerciumWeb.Interfaces;

namespace CommerciumWeb.Normal_Classes
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<ProductModel>> GetProductByIdAsync(int productId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"product/{productId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<ProductModel>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<ProductModel> { Errors = new List<string> { $"Ürün getirilemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ProductModel>>> GetAllProductsAsync()
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync("product/all");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ProductModel>> { Errors = new List<string> { $"Ürünler getirilemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> CreateProductAsync(ProductModel createProductModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("product/create", createProductModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Ürün oluşturulamadı: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> UpdateProductAsync(ProductModel updateProductModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PutAsJsonAsync("product/update", updateProductModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Ürün güncellenemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> DeleteProductAsync(int productId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"product/delete/{productId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Ürün silinemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> IncreaseProductLikeCountAsync(int productId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"product/increase-like/{productId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Ürün beğeni sayısı artırılamadı: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> IncreaseProductClickCountAsync(int productId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"product/increase-click/{productId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Ürün tıklama sayısı artırılamadı: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> IncreaseProductViewCountAsync(int productId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"product/increase-view/{productId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Ürün görüntülenme sayısı artırılamadı: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> AddProductCategoryAsync(ProductCategoryModel productCategoryModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("product/add-category", productCategoryModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Ürün kategorisi eklenemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> RemoveProductCategoryAsync(ProductCategoryModel productCategoryModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("product/remove-category", productCategoryModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Ürün kategorisi kaldırılamadı: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> AddProductTagAsync(ProductTagModel createProductTagModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("product/add-tag", createProductTagModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Ürün etiketi eklenemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> RemoveProductTagAsync(ProductTagModel updateProductTagModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("product/remove-tag", updateProductTagModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Ürün etiketi kaldırılamadı: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByBusinessAsync(int businessProfileId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"product/business/{businessProfileId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);
                return result ?? new ReturnModel<IEnumerable<ProductModel>> { Data = new List<ProductModel>() };
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ProductModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByCategoryAsync(int categoryId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"product/category/{categoryId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);
                return result ?? new ReturnModel<IEnumerable<ProductModel>> { Data = new List<ProductModel>() };
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ProductModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ProductModel>>> GetProductsByTagAsync(int tagId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"product/tag/{tagId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);
                return result ?? new ReturnModel<IEnumerable<ProductModel>> { Data = new List<ProductModel>() };
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ProductModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ProductModel>>> GetLatestProductsAsync(int count)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"product/latest?count={count}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);
                return result ?? new ReturnModel<IEnumerable<ProductModel>> { Data = new List<ProductModel>() };
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ProductModel>> { Errors = new List<string> { ex.Message } };
            }
        }

    }

}
