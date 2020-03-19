using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using splitourbill_backend.Models.DomainModels;
using splitourbill_backend.Models.RequestModels;
using splitourbill_backend.Models.ResponseModels;
using splitourbill_backend.Persistence;

namespace splitourbill_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendshipsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FriendshipsController(IUserRepository userRepository, IFriendshipRepository friendshipRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _friendshipRepository = friendshipRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{friendshipId}")]
        public async Task<IActionResult> GetFriendship(Guid friendshipId)
        {
            var friendship = await _friendshipRepository.GetFriendship(friendshipId);

            return Ok(friendship);
        }

        [HttpGet("requests/{userId}")]
        public async Task<IActionResult> GetFriendRequests(Guid userId)
        {
            var pendingFriendRequestResponses = new List<PendingFriendRequestResponse>();

            var requests = await _friendshipRepository.GetPendingFriendRequestsByRequesteeId(userId);

            foreach (var request in requests)
            {
                pendingFriendRequestResponses.Add(new PendingFriendRequestResponse()
                {
                    Id = request.Id,
                    Requestor = _mapper.Map<UserSimpleResponse>(await _userRepository.GetUserById(request.RequestorId))
                });
            }

            return Ok(pendingFriendRequestResponses);
        }

        [HttpPost]
        public async Task<IActionResult> SendFriendRequest([FromBody] NewFriendshipCreationRequest newFriendshipCreationRequest)
        {
            var newFriendship = _mapper.Map<Friendship>(newFriendshipCreationRequest);
            await _friendshipRepository.CreateNewFriendship(newFriendship);

            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetFriendship), new { friendshipId = newFriendship.Id }, newFriendship);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateFriendship([FromBody] UpdateFriendshipRequest updateFriendshipRequest)
        {
            var friendship = await _friendshipRepository.GetFriendship(updateFriendshipRequest.Id);
            friendship.Status = updateFriendshipRequest.Status;

            _friendshipRepository.UpdateFriendship(friendship);
            await _unitOfWork.CompleteAsync();

            return Ok(friendship);
        }
    }
}