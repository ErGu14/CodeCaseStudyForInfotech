using CommerciumWeb.Interfaces;
using CommerciumWeb.Models;
using CommerciumWeb.Models.MessageModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommerciumWeb.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IToastNotification _toastNotification;

        public MessageController(IMessageService messageService, IToastNotification toastNotification)
        {
            _messageService = messageService;
            _toastNotification = toastNotification;
        }

        [HttpPost("message/send")]
        public async Task<IActionResult> SendMessage([FromForm] MessageModel messageModel, IFormFile? file)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(messageModel.SenderId) || string.IsNullOrEmpty(messageModel.ReceiverId))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz mesaj bilgileri. Lütfen eksiksiz doldurun.");
                return BadRequest("Eksik veya geçersiz mesaj bilgileri.");
            }

            try
            {
                var response = await _messageService.SendMessageAsync(messageModel, file);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Mesaj başarıyla gönderildi.");
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

        [HttpPut("message/update")]
        public async Task<IActionResult> UpdateMessage([FromBody] MessageModel messageModel)
        {
            if (!ModelState.IsValid || messageModel.MessageId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz mesaj güncelleme isteği.");
                return BadRequest("Eksik veya geçersiz mesaj bilgileri.");
            }

            try
            {
                var response = await _messageService.UpdateMessageAsync(messageModel);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Mesaj başarıyla güncellendi.");
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

        [HttpDelete("message/delete/{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            if (messageId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz mesaj kimliği.");
                return BadRequest("Mesaj kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _messageService.DeleteMessageAsync(messageId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Mesaj başarıyla silindi.");
                    return Ok(response);
                }
                _toastNotification.AddErrorToastMessage("Mesaj silinemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpDelete("message/delete-all/{conversationId}")]
        public async Task<IActionResult> DeleteAllMessagesInConversation(int conversationId)
        {
            if (conversationId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz konuşma kimliği.");
                return BadRequest("Konuşma kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _messageService.DeleteAllMessagesInConversationAsync(conversationId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Konuşmadaki tüm mesajlar silindi.");
                    return Ok(response);
                }
                _toastNotification.AddErrorToastMessage("Mesajlar silinemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpGet("message/user/{userId}/conversations")]
        public async Task<IActionResult> GetUserConversations(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _toastNotification.AddErrorToastMessage("Geçersiz kullanıcı kimliği.");
                return BadRequest("Kullanıcı kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _messageService.GetUserConversationsAsync(userId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Konuşmalar getirilemedi.");
                return View(new List<ConversationModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<ConversationModel>());
            }
        }

        [HttpGet("message/conversation/{conversationId}")]
        public async Task<IActionResult> GetMessagesByConversation(int conversationId)
        {
            if (conversationId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz konuşma kimliği.");
                return BadRequest("Konuşma kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _messageService.GetMessagesByConversationAsync(conversationId);
                if (response.Errors == null)
                {
                    return View(response.Data);
                }
                _toastNotification.AddErrorToastMessage("Mesajlar getirilemedi.");
                return View(new List<MessageModel>());
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return View(new List<MessageModel>());
            }
        }

        [HttpGet("message/conversation/{conversationId}/last")]
        public async Task<IActionResult> GetLastMessageByConversation(int conversationId)
        {
            if (conversationId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz konuşma kimliği.");
                return BadRequest("Konuşma kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _messageService.GetLastMessageByConversationAsync(conversationId);
                if (response.Errors == null)
                {
                    return Ok(response);
                }
                _toastNotification.AddErrorToastMessage("Son mesaj getirilemedi.");
                return NotFound();
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }

        [HttpPost("message/mark-as-read/{messageId}")]
        public async Task<IActionResult> MarkMessageAsRead(int messageId)
        {
            if (messageId == 0)
            {
                _toastNotification.AddErrorToastMessage("Geçersiz mesaj kimliği.");
                return BadRequest("Mesaj kimliği belirtilmelidir.");
            }

            try
            {
                var response = await _messageService.MarkMessageAsReadAsync(messageId);
                if (response.Errors == null)
                {
                    _toastNotification.AddSuccessToastMessage("Mesaj okundu olarak işaretlendi.");
                    return Ok(response);
                }
                _toastNotification.AddErrorToastMessage("Mesaj işaretlenemedi.");
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage($"Hata: {ex.Message}");
                return StatusCode(500, "Sunucu hatası.");
            }
        }
    }
}
