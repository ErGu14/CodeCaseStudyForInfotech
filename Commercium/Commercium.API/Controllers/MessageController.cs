using Commercium.Service.Interfaces;
using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.MessageRMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commercium.API.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : CustomizingController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // Mesaj Gönderme - User, SalesRepresentative erişebilir
        [Authorize(Roles = "User, SalesRepresentative")]
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] CreateMessageRM createMessageRM, [FromForm] IFormFile? file)
        {
            var response = await _messageService.SendMessageAsync(createMessageRM, file);
            return CreateReturn(response);
        }

        // Mesaj Güncelleme - User, Admin ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, Admin, SalesRepresentative")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMessage([FromBody] UpdateMessageRM updateMessageRM)
        {
            var response = await _messageService.UpdateMessageAsync(updateMessageRM);
            return CreateReturn(response);
        }

        // Mesaj Silme - User, Admin ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, Admin, SalesRepresentative")]
        [HttpDelete("delete/{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            var response = await _messageService.DeleteMessageAsync(messageId);
            return CreateReturn(response);
        }

        // Tüm Mesajları Konuşma İçin Silme - Admin ve SalesRepresentative erişebilir
        [Authorize(Roles = "Admin, SalesRepresentative")]
        [HttpDelete("delete-all/{conversationId}")]
        public async Task<IActionResult> DeleteAllMessagesInConversation(int conversationId)
        {
            var response = await _messageService.DeleteAllMessagesInConversationAsync(conversationId);
            return CreateReturn(response);
        }

        // Kullanıcının Tüm Konuşmalarını Getirme - Admin ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, Admin, SalesRepresentative")]
        [HttpGet("user/{userId}/conversations")]
        public async Task<IActionResult> GetUserConversations(string userId)
        {
            var response = await _messageService.GetUserConversationsAsync(userId);
            return CreateReturn(response);
        }

        // Konuşma İçerisindeki Tüm Mesajları Getirme - Admin ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, Admin, SalesRepresentative")]
        [HttpGet("conversation/{conversationId}")]
        public async Task<IActionResult> GetMessagesByConversation(int conversationId)
        {
            var response = await _messageService.GetMessagesByConversationAsync(conversationId);
            return CreateReturn(response);
        }

        // Konuşma İçerisindeki Son Mesajı Getirme - Admin ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, Admin, SalesRepresentative")]
        [HttpGet("conversation/{conversationId}/last")]
        public async Task<IActionResult> GetLastMessageByConversation(int conversationId)
        {
            var response = await _messageService.GetLastMessageByConversationAsync(conversationId);
            return CreateReturn(response);
        }

        // Kullanıcının Okunmamış Mesajlarını Getirme - Admin ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, Admin, SalesRepresentative")]
        [HttpGet("user/{userId}/unread")]
        public async Task<IActionResult> GetUnreadMessages(string userId)
        {
            var response = await _messageService.GetUnreadMessagesAsync(userId);
            return CreateReturn(response);
        }

        // Mesajı Okundu Olarak İşaretleme - User, Admin ve SalesRepresentative erişebilir
        [Authorize(Roles = "User, Admin, SalesRepresentative")]
        [HttpPost("mark-as-read/{messageId}")]
        public async Task<IActionResult> MarkMessageAsRead(int messageId)
        {
            var response = await _messageService.MarkMessageAsReadAsync(messageId);
            return CreateReturn(response);
        }
    }

}
