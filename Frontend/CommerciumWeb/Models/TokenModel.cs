﻿using System.Text.Json.Serialization;

namespace CommerciumWeb.Models
{
    public class TokenModel
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expirationDate")]
        public DateTime ExpirationDate { get; set; }
    }
}