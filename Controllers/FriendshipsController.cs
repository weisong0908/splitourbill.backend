using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using splitourbill_backend.Models.ResponseModels;
using splitourbill_backend.Persistence;

namespace splitourbill_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendshipsController: ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IMapper _mapper;

        public FriendshipsController(IUserRepository userRepository, IFriendshipRepository friendshipRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _friendshipRepository = friendshipRepository;
            _mapper = mapper;
        }

        [HttpGet("requests/{userId}")]
        public async Task<IActionResult> GetFriendRequests(Guid userId)
        {
            var pendingFriendRequestResponses = new List<PendingFriendRequestResponse>();
            
            var requests = await _friendshipRepository.GetPendingFriendRequestsByRequesteeId(userId);

            foreach(var request in requests)
            {
                pendingFriendRequestResponses.Add(new PendingFriendRequestResponse()
                {
                    Id = request.Id,
                    Requestor = _mapper.Map<UserSimpleResponse>(await _userRepository.GetUserById(request.RequestorId))
                });
            }

            return Ok(pendingFriendRequestResponses);
        }
    }
}