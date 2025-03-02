using Commercium.Shared.Enums;
using CommerciumWeb.Bases;
using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using System.Text.Json;

namespace CommerciumWeb.Normal_Classes
{
    public class ActivityLogService : BaseService, IActivityLogService
    {
        public ActivityLogService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<ActivityLogModel>> GetActivityByIdAsync(int activityLogId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"activity-log/{activityLogId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<ActivityLogModel>>(responseBody, _jsonSerializerOptions);
                return result;
            }
            catch (Exception ex)
            {
                return new ReturnModel<ActivityLogModel> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ActivityLogModel>>> GetUserActivitiesAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"activity-log/user/{userId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<IEnumerable<ActivityLogModel>>>(responseBody, _jsonSerializerOptions);
                return result;
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ActivityLogModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ActivityLogModel>>> GetActivitiesByEntityAsync(int entityId, EntityType entityType)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"activity-log/entity/{entityId}/{(int)entityType}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<IEnumerable<ActivityLogModel>>>(responseBody, _jsonSerializerOptions);
                return result;
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ActivityLogModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ActivityLogModel>>> GetRecentUserActivitiesAsync(string userId, int count)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"activity-log/user/{userId}/recent/{count}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<IEnumerable<ActivityLogModel>>>(responseBody, _jsonSerializerOptions);
                return result;
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ActivityLogModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ActivityLogModel>>> GetActivitiesByTypeAsync(ActivityType activityType)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"activity-log/type/{(int)activityType}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<IEnumerable<ActivityLogModel>>>(responseBody, _jsonSerializerOptions);
                return result;
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ActivityLogModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ActivityLogModel>>> GetActivitiesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"activity-log/date-range?startDate={startDate:O}&endDate={endDate:O}");
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<IEnumerable<ActivityLogModel>>>(responseBody, _jsonSerializerOptions);
                return result;
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ActivityLogModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> CreateActivityAsync(CreateActivityLogModel createActivityLogModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("activity-log/create", createActivityLogModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
                return result;
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }
    }

}
