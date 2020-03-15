using System;
using System.Text.Json.Serialization;

namespace splitourbill_backend.Models.DomainModels
{
    public class Friendship
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("requestor")]
        public Guid RequestorId { get; set; }
        [JsonPropertyName("requestee")]
        public Guid RequesteeId { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}