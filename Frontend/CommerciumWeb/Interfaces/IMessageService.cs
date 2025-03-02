using CommerciumWeb.Models;
using CommerciumWeb.Models.MessageModels;

namespace CommerciumWeb.Interfaces
{
    public interface IMessageService
    {
        Task<ReturnModel<string>> SendMessageAsync(MessageModel createMessageModel, IFormFile? file);
        Task<ReturnModel<string>> UpdateMessageAsync(MessageModel updateMessageModel);
        Task<ReturnModel<string>> DeleteMessageAsync(int messageId);
        Task<ReturnModel<string>> DeleteAllMessagesInConversationAsync(int conversationId);
        Task<ReturnModel<IEnumerable<ConversationModel>>> GetUserConversationsAsync(string userId);
        Task<ReturnModel<IEnumerable<MessageModel>>> GetMessagesByConversationAsync(int conversationId);
        Task<ReturnModel<MessageModel>> GetLastMessageByConversationAsync(int conversationId);
        Task<ReturnModel<IEnumerable<MessageModel>>> GetUnreadMessagesAsync(string userId);
        Task<ReturnModel<string>> MarkMessageAsReadAsync(int messageId);
    }

}
