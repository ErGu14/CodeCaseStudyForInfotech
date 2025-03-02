using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class BusinessProfileModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "İşletme adı gereklidir.")]
    [StringLength(100, ErrorMessage = "İşletme adı en fazla 100 karakter olabilir.")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
    public string? Description { get; set; }

    [JsonPropertyName("ownerId")]
    [Required(ErrorMessage = "İşletme sahibi gereklidir.")]
    public string OwnerId { get; set; }

    [JsonPropertyName("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonPropertyName("updatedDate")]
    public DateTime? UpdatedDate { get; set; }

    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; } = 0;

    [JsonPropertyName("viewCount")]
    public int ViewCount { get; set; } = 0;

    [JsonPropertyName("clickCount")]
    public int ClickCount { get; set; } = 0;
}
