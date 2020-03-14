using System;

namespace splitourbill_backend.Models.RequestModels
{
    public class NewFriendshipCreationRequest
    {
        public Guid RequestorId { get; set; }
        public Guid RequesteeId { get; set; }
    }
}