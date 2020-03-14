using System;
using System.Collections;
using System.Collections.Generic;

namespace splitourbill_backend.Models.ResponseModels
{
    public class UserFullResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }

        public IEnumerable<UserSimpleResponse> Friends { get; set; }

        public UserFullResponse()
        {
            Friends = new List<UserSimpleResponse>();
        }
    }
}