using System;
using System.Text.Json.Serialization;

namespace splitourbill_backend.Models.DomainModels
{
    public class Friendship
    {
        public Guid Id { get; set; }
        public Guid RequestorId { get; set; }
        public Guid RequesteeId { get; set; }
        public string Status { get; set; }
    }
}