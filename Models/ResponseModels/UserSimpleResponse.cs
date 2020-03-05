using System;

namespace splitourbill_backend.Models.ResponseModels
{
    public class UserSimpleResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}