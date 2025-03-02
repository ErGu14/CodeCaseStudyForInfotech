using System.Text.Json.Serialization;

namespace CommerciumWeb.Models.MessageModels
{
    public class ConversationModel
    {
        [JsonPropertyName("conversationId")]
        public int ConversationId { get; set; } // Konuşma ID

        [JsonPropertyName("senderId")]
        public string SenderId { get; set; } // Gönderen Kullanıcı ID

        [JsonPropertyName("sender")]
        public UserModel Sender { get; set; } // Gönderen Kullanıcı Bilgileri

        [JsonPropertyName("receiverId")]
        public string ReceiverId { get; set; } // Alıcı Kullanıcı ID

        [JsonPropertyName("receiver")]
        public UserModel Receiver { get; set; } // Alıcı Kullanıcı Bilgileri

        [JsonPropertyName("lastMessageDate")]
        public DateTime LastMessageDate { get; set; } // Son Mesaj Tarihi

        [JsonPropertyName("messages")]
        public IEnumerable<MessageModel> Messages { get; set; } = new List<MessageModel>(); // Mesajlar
    }
}
