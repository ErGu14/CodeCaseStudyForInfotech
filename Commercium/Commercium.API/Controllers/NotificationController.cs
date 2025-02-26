using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.NotificationRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/notification")]
    public class NotificationController : CustomizingController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // Bildirim Oluşturma - Admin ve BusinessOwner erişebilir
        [Authorize(Roles = "Admin, BusinessOwner")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationRM createNotificationRM)
        {
            var response = await _notificationService.CreateNotificationAsync(createNotificationRM);
            return CreateReturn(response);
        }

        // Kullanıcı Bildirimlerini Getirme - User ve Admin erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserNotifications(string userId)
        {
            var response = await _notificationService.GetUserNotificationsAsync(userId);
            return CreateReturn(response);
        }

        // Bildirim Detaylarını ID ile Getirme - Admin ve User erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("{notificationId}")]
        public async Task<IActionResult> GetNotificationById(int notificationId)
        {
            var response = await _notificationService.GetNotificationByIdAsync(notificationId);
            return CreateReturn(response);
        }

        // Bildirim Silme - Admin ve User erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpDelete("{notificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            var response = await _notificationService.DeleteNotificationAsync(notificationId);
            return CreateReturn(response);
        }

        // Kullanıcıya Ait Tüm Bildirimleri Temizleme - Admin ve User erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpDelete("clear-user/{userId}")]
        public async Task<IActionResult> ClearUserNotifications(string userId)
        {
            var response = await _notificationService.ClearUserNotificationsAsync(userId);
            return CreateReturn(response);
        }

        // Okunmamış Bildirimleri Getirme - Admin ve User erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("user/{userId}/unread")]
        public async Task<IActionResult> GetUnreadNotifications(string userId)
        {
            var response = await _notificationService.GetUnreadNotificationsAsync(userId);
            return CreateReturn(response);
        }

        // Bildirimi Okundu Olarak İşaretleme - Admin ve User erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpPost("mark-as-read/{notificationId}")]
        public async Task<IActionResult> MarkNotificationAsRead(int notificationId)
        {
            var response = await _notificationService.MarkNotificationAsReadAsync(notificationId);
            return CreateReturn(response);
        }

        // Tüm Bildirimleri Okundu Olarak İşaretleme - Admin ve User erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpPost("mark-all-as-read/{userId}")]
        public async Task<IActionResult> MarkAllNotificationsAsRead(string userId)
        {
            var response = await _notificationService.MarkAllNotificationsAsReadAsync(userId);
            return CreateReturn(response);
        }

        // En Son Bildirimleri Getirme - Admin ve User erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("user/{userId}/latest")]
        public async Task<IActionResult> GetLatestNotifications(string userId, [FromQuery] int count)
        {
            var response = await _notificationService.GetLatestNotificationsAsync(userId, count);
            return CreateReturn(response);
        }

        // Okunmamış Bildirim Sayısını Getirme - Admin ve User erişebilir
        [Authorize(Roles = "User, Admin")]
        [HttpGet("user/{userId}/unread-count")]
        public async Task<IActionResult> GetUnreadNotificationCount(string userId)
        {
            var response = await _notificationService.GetUnreadNotificationCountAsync(userId);
            return CreateReturn(response);
        }
    }

}
