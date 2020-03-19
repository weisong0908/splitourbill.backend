using System;

namespace splitourbill_backend.Models.RequestModels
{
    public class UpdateFriendshipRequest
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}