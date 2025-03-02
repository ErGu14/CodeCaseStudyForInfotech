using CommerciumWeb.Bases;
using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using System.Text.Json;

namespace CommerciumWeb.Normal_Classes
{
    public class NotificationService : BaseService, INotificationService
    {
        public NotificationService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<string>> CreateNotificationAsync(NotificationModel createNotificationModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("notification/create", createNotificationModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Bildirim oluşturulamadı: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<IEnumerable<NotificationModel>>> GetUserNotificationsAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"notification/user/{userId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<NotificationModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<NotificationModel>> { Errors = new List<string> { $"Bildirimler getirilemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<NotificationModel>> GetNotificationByIdAsync(int notificationId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"notification/{notificationId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<NotificationModel>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<NotificationModel> { Errors = new List<string> { $"Bildirim getirilemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> DeleteNotificationAsync(int notificationId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"notification/{notificationId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Bildirim silinemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> ClearUserNotificationsAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"notification/clear-user/{userId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Bildirimler temizlenemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<IEnumerable<NotificationModel>>> GetUnreadNotificationsAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"notification/user/{userId}/unread");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<NotificationModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<NotificationModel>> { Errors = new List<string> { $"Okunmamış bildirimler getirilemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> MarkNotificationAsReadAsync(int notificationId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"notification/mark-as-read/{notificationId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Bildirim okundu olarak işaretlenemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<string>> MarkAllNotificationsAsReadAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"notification/mark-all-as-read/{userId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { $"Tüm bildirimler okundu olarak işaretlenemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<IEnumerable<NotificationModel>>> GetLatestNotificationsAsync(string userId, int count)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"notification/user/{userId}/latest?count={count}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<NotificationModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<NotificationModel>> { Errors = new List<string> { $"En son bildirimler getirilemedi: {ex.Message}" } };
            }
        }

        public async Task<ReturnModel<int>> GetUnreadNotificationCountAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"notification/user/{userId}/unread-count");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<int>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<int> { Errors = new List<string> { $"Okunmamış bildirim sayısı getirilemedi: {ex.Message}" } };
            }
        }
    }

}
