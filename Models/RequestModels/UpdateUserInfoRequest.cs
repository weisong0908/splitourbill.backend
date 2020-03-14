using System;

namespace splitourbill_backend.Models.RequestModels
{
    public class UpdateUserInfoRequest
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
    }
}