using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class UserFollowModel
{
    [JsonPropertyName("followerId")]
    [Required(ErrorMessage = "Takip eden kullanıcı ID'si gereklidir.")]
    public string FollowerId { get; set; } // Takip eden kullanıcı ID

    [JsonPropertyName("follower")]
    public UserModel? Follower { get; set; } // Takip eden kullanıcı bilgisi

    [JsonPropertyName("followedId")]
    [Required(ErrorMessage = "Takip edilen kullanıcı ID'si gereklidir.")]
    public string FollowedId { get; set; } // Takip edilen kullanıcı ID

    [JsonPropertyName("followed")]
    public UserModel? Followed { get; set; } // Takip edilen kullanıcı bilgisi

    
}
