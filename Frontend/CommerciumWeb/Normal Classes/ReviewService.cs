using CommerciumWeb.Bases;
using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using System.Text.Json;

namespace CommerciumWeb.Normal_Classes
{
    public class ReviewService : BaseService, IReviewService
    {
        public ReviewService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<string>> CreateReviewAsync(ReviewModel createReviewModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("review/create", createReviewModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> UpdateReviewAsync(ReviewModel updateReviewModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PutAsJsonAsync("review/update", updateReviewModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> DeleteReviewAsync(int reviewId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"review/delete/{reviewId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ReviewModel>>> GetReviewsByProductAsync(int productId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"review/product/{productId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<ReviewModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ReviewModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ReviewModel>>> GetReviewsByServiceAsync(int serviceId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"review/service/{serviceId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<ReviewModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ReviewModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ReviewModel>>> GetUserReviewsAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"review/user/{userId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<ReviewModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ReviewModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<ReviewModel>> GetReviewByIdAsync(int reviewId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"review/{reviewId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<ReviewModel>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<ReviewModel> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<double>> GetAverageRatingForProductAsync(int productId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"review/product/{productId}/average-rating");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<double>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<double> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<double>> GetAverageRatingForServiceAsync(int serviceId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"review/service/{serviceId}/average-rating");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<double>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<double> { Errors = new List<string> { ex.Message } };
            }
        }
    }
}
