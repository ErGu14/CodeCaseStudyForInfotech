using CommerciumWeb.Bases;
using CommerciumWeb.Models.MessageModels;
using CommerciumWeb.Models;
using System.Text.Json;
using System.Text;
using CommerciumWeb.Interfaces;

namespace CommerciumWeb.Normal_Classes
{
    public class MessageService : BaseService, IMessageService
    {
        public MessageService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ReturnModel<string>> SendMessageAsync(MessageModel createMessageModel, IFormFile? file)
        {
            try
            {
                var client = GetHttpClient();
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(JsonSerializer.Serialize(createMessageModel), Encoding.UTF8, "application/json"));

                if (file != null)
                {
                    var streamContent = new StreamContent(file.OpenReadStream());
                    content.Add(streamContent, "file", file.FileName);
                }

                var response = await client.PostAsync("message/send", content);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> UpdateMessageAsync(MessageModel updateMessageModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PutAsJsonAsync("message/update", updateMessageModel);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> DeleteMessageAsync(int messageId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"message/delete/{messageId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> DeleteAllMessagesInConversationAsync(int conversationId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.DeleteAsync($"message/delete-all/{conversationId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<ConversationModel>>> GetUserConversationsAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"message/user/{userId}/conversations");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<ConversationModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<ConversationModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<MessageModel>>> GetMessagesByConversationAsync(int conversationId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"message/conversation/{conversationId}");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<MessageModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<MessageModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<MessageModel>> GetLastMessageByConversationAsync(int conversationId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"message/conversation/{conversationId}/last");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<MessageModel>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<MessageModel> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<IEnumerable<MessageModel>>> GetUnreadMessagesAsync(string userId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"message/user/{userId}/unread");
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<IEnumerable<MessageModel>>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<IEnumerable<MessageModel>> { Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<ReturnModel<string>> MarkMessageAsReadAsync(int messageId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsync($"message/mark-as-read/{messageId}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReturnModel<string>>(responseBody, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                return new ReturnModel<string> { Errors = new List<string> { ex.Message } };
            }
        }
    }

}
