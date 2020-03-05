using System;
using System.Text.Json.Serialization;

namespace splitourbill_backend.Models.DomainModels
{
    public class Relationship
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("requestor")]
        public Guid Requestor { get; set; }
        [JsonPropertyName("requestee")]
        public Guid Requestee { get; set; }
        [JsonPropertyName("relationshipType")]
        public string RelationshipType { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}