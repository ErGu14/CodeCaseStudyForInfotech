using CommerciumWeb.Bases;
using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using System.Text.Json;

namespace CommerciumWeb.Normal_Classes
{
    public class UserFollowService : BaseService, IUserFollowService
    {
        public UserFollowService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<string>> FollowUserAsync(UserFollowModel followModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("api/user-follow/follow", followModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> UnfollowUserAsync(string followerId, string followedId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"api/user-follow/unfollow?followerId={followerId}&followedId={followedId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<UserModel>>> GetFollowersAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"api/user-follow/followers/{userId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<UserModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<UserModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<UserModel>>> GetFollowingAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"api/user-follow/following/{userId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<UserModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<UserModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<bool>> IsUserFollowingAsync(string followerId, string followedId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"api/user-follow/is-following?followerId={followerId}&followedId={followedId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<bool>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<bool> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<int>> GetFollowerCountAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"api/user-follow/follower-count/{userId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<int>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<int> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<int>> GetFollowingCountAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"api/user-follow/following-count/{userId}");
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
