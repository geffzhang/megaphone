﻿using System.Text.Json.Serialization;

namespace Megaphone.API.Models.Representations
{
    public class ResourceRepresentation : Representation
    {
        [JsonPropertyName("display")]
        public string Display { get; internal set; }
        [JsonPropertyName("url")]
        public string Url { get; internal set; }
    }
}