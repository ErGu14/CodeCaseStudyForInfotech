using Commercium.Shared.ReturnRMs;
using Commercium.Shared.Users.MessageRMs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface IMessageService
    {
        // Mesaj Yönetimi
        Task<ReturnRM<string>> SendMessageAsync(CreateMessageRM createMessageRM, IFormFile? file);
        Task<ReturnRM<string>> UpdateMessageAsync(UpdateMessageRM updateMessageRM);
        Task<ReturnRM<string>> DeleteMessageAsync(int messageId);
        Task<ReturnRM<string>> DeleteAllMessagesInConversationAsync(int conversationId);
        Task<ReturnRM<string>> DeleteAllMessagesByUserAsync(string userId);

        // Konuşma Yönetimi
        Task<ReturnRM<IEnumerable<ConversationRM>>> GetUserConversationsAsync(string userId);
        Task<ReturnRM<IEnumerable<MessageRM>>> GetMessagesByConversationAsync(int conversationId);
        Task<ReturnRM<MessageRM>> GetLastMessageByConversationAsync(int conversationId);

        // Okunmamış Mesaj Yönetimi
        Task<ReturnRM<IEnumerable<MessageRM>>> GetUnreadMessagesAsync(string userId);
        Task<ReturnRM<string>> MarkMessageAsReadAsync(int messageId);
    }

}
