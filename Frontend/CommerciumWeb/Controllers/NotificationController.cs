using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CommerciumWeb.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IToastNotification _toastNotification;

        public NotificationController(INotificationService notificationService, IToastNotification toastNotification)
        {
            _notificationService = notificationService;
            _toastNotification = toastNotification;
        }

        [HttpPost("notification/create")]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationModel createNotificationModel)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz bildirim bilgileri.");
                return BadRequest("Eksik veya hatalı bildirim bilgileri.");
            }

            try
            {
                var response = await _notificationService.CreateNotificationAsync(createNotificationModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Bildirim başarıyla oluşturuldu.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage(string.Join(" ", response.Errors));
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpGet("notification/user")]
        public async Task<IActionResult> GetUserNotifications()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Kullanıcı kimliği bulunamadı.");
            }

            try
            {
                var response = await _notificationService.GetUserNotificationsAsync(userId);
                if (response.Errors == null)
                {
                    return Ok(response.Data);
                }

                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Bildirimler alınırken hata oluştu: {ex.Message}" });
            }
        }


        [HttpGet("notification/{notificationId}")]
        public async Task<IActionResult> GetNotificationById(int notificationId)
        {
            if (notificationId <= 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz bildirim kimliği.");
                return BadRequest("Bildirim kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _notificationService.GetNotificationByIdAsync(notificationId);
                if (response.Errors == null)
                {
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Bildirim bulunamadı.");
                return NotFound();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpDelete("notification/{notificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            if (notificationId <= 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz bildirim kimliği.");
                return BadRequest("Bildirim kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _notificationService.DeleteNotificationAsync(notificationId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Bildirim başarıyla silindi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Bildirim silinemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpDelete("notification/clear-user/{userId}")]
        public async Task<IActionResult> ClearUserNotifications(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kullanıcı kimliği.");
                return BadRequest("Kullanıcı kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _notificationService.ClearUserNotificationsAsync(userId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Tüm bildirimler temizlendi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Bildirimler temizlenemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpGet("notification/user/{userId}/unread")]
        public async Task<IActionResult> GetUnreadNotifications(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kullanıcı kimliği.");
                return BadRequest("Kullanıcı kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _notificationService.GetUnreadNotificationsAsync(userId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Okunmamış bildirimler getirilemedi.");
                return View(new List<NotificationModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<NotificationModel>());
            }
        }

        [HttpPut("notification/mark-as-read/{notificationId}")]
        public async Task<IActionResult> MarkNotificationAsRead(int notificationId)
        {
            if (notificationId <= 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz bildirim kimliği.");
                return BadRequest("Bildirim kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _notificationService.MarkNotificationAsReadAsync(notificationId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Bildirim okundu olarak işaretlendi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Bildirim işaretlenemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpPut("notification/mark-all-as-read/{userId}")]
        public async Task<IActionResult> MarkAllNotificationsAsRead(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kullanıcı kimliği.");
                return BadRequest("Kullanıcı kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _notificationService.MarkAllNotificationsAsReadAsync(userId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Tüm bildirimler okundu olarak işaretlendi.");
                    return Ok(response);
                }

                _toastNotification.AddErrorToastMessage("Bildirimler işaretlenemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpGet("notification/user/{userId}/latest/{count}")]
        public async Task<IActionResult> GetLatestNotifications(string userId, int count)
        {
            if (string.IsNullOrEmpty(userId) || count <= 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz giriş!");
                return BadRequest("Kullanıcı kimliği ve bildirim sayısı belirtilmelidir.");
            }

            try
            {
                var response = await _notificationService.GetLatestNotificationsAsync(userId, count);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }

                _toastNotification.AddErrorToastMessage("Son bildirimler getirilemedi.");
                return View(new List<NotificationModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<NotificationModel>());
            }
        }
    }
}
