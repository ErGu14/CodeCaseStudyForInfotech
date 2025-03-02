using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class MessageModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("senderId")]
    [Required(ErrorMessage = "Gönderen kullanıcı ID'si gereklidir.")]
    public string SenderId { get; set; }

    [JsonPropertyName("receiverId")]
    [Required(ErrorMessage = "Alıcı kullanıcı ID'si gereklidir.")]
    public string ReceiverId { get; set; }

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

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
