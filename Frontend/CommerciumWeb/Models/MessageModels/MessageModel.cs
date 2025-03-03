using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class MessageModel
{
    [JsonPropertyName("messageId")]
    public int MessageId { get; set; } // RM ile uyumlu hale getirildi.

    [JsonPropertyName("senderId")]
    [Required(ErrorMessage = "Gönderen kullanıcı ID'si gereklidir.")]
    public string SenderId { get; set; }

    [JsonPropertyName("sender")]
    public UserModel? Sender { get; set; } // Kullanıcı detaylarını da ekledik.

    [JsonPropertyName("receiverId")]
    [Required(ErrorMessage = "Alıcı kullanıcı ID'si gereklidir.")]
    public string ReceiverId { get; set; }

    [JsonPropertyName("receiver")]
    public UserModel? Receiver { get; set; } // Kullanıcı detaylarını da ekledik.

    [JsonPropertyName("conversationId")]
    public int ConversationId { get; set; }

    [JsonPropertyName("content")]
    [Required(ErrorMessage = "Mesaj içeriği gereklidir.")]
    [StringLength(1000, ErrorMessage = "Mesaj içeriği en fazla 1000 karakter olabilir.")]
    public string Content { get; set; }

    [JsonPropertyName("fileUrl")]
    public string? FileUrl { get; set; } // Opsiyonel dosya (görsel, belge vb.)

    [JsonPropertyName("isRead")]
    public bool IsRead { get; set; } = false;

    [JsonPropertyName("sentDate")]
    public DateTime SentDate { get; set; } = DateTime.UtcNow; // `CreatedAt` yerine `SentDate` kullanıldı.
}

