using Megaphone.API.Models.Representations.Links;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Megaphone.API.Models.Representations
{
    public class ResourceListRepresentation : Representation
    {
        public ResourceListRepresentation(DateTime date)
        {
            Date = date;
            base.AddLink(Relations.Self, $"api/resources{date.Year}/{date.Month}/{date.Day}");

            var previousDate = date.Subtract(TimeSpan.FromDays(1d));
            base.AddLink(Relations.Previous, $"api/resources{previousDate.Year}/{previousDate.Month}/{previousDate.Day}");

            if (date.Date != DateTimeOffset.UtcNow.Date)
            {
                var nextDate = date.Add(TimeSpan.FromDays(1d));
                base.AddLink(Relations.Next, $"api/resources{nextDate.Year}/{nextDate.Month}/{nextDate.Day}");
            }
        }

        [JsonPropertyName("resources")]
        public List<ResourceRepresentation> Resources { get; set; } = new List<ResourceRepresentation>();

        [JsonPropertyName("updated")]
        public DateTimeOffset Updated { get; internal set; }

        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; internal set; }
    }
}