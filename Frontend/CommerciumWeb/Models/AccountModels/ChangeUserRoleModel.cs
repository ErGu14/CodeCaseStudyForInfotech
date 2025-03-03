using Commercium.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ChangeUserRoleModel
{
    [JsonPropertyName("userId")]
    [Required]
    public string UserId { get; set; }

    [JsonPropertyName("newRole")]
    [Required]
    public UserRole NewRole { get; set; } 
}
