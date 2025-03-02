using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class UserFollowModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; } // Takip kaydının benzersiz ID'si

    [JsonPropertyName("followerId")]
    [Required(ErrorMessage = "Takip eden kullanıcı ID'si gereklidir.")]
    public string FollowerId { get; set; } // Takip eden kullanıcı ID

    [JsonPropertyName("followedId")]
    [Required(ErrorMessage = "Takip edilen kullanıcı ID'si gereklidir.")]
    public string FollowedId { get; set; } // Takip edilen kullanıcı ID

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Takip işleminin oluşturulma tarihi

    [JsonPropertyName("isFollowing")]
    public bool IsFollowing { get; set; } // Kullanıcının takip edip etmediğini belirten boolean değer

    [JsonPropertyName("followerCount")]
    public int FollowerCount { get; set; } // Kullanıcının takipçi sayısı

    [JsonPropertyName("followingCount")]
    public int FollowingCount { get; set; } // Kullanıcının takip ettiği kişi sayısı

    [JsonPropertyName("followers")]
    public List<UserModel>? Followers { get; set; } // Kullanıcının takipçileri

    [JsonPropertyName("following")]
    public List<UserModel>? Following { get; set; } // Kullanıcının takip ettiği kişiler
}
