using System;

namespace splitourbill_backend.Models.ResponseModels
{
    public class PendingFriendRequestResponse
    {
        public Guid Id { get; set; }
        public UserSimpleResponse Requestor { get; set; }
    }
}