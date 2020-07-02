using System;
using System.Text.Json.Serialization;

namespace Megaphone.API.Models
{
    public class NewFeed
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }
}
