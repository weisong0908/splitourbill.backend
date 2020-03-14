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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = _mapper.Map<IEnumerable<UserSimpleResponse>>(await _userRepository.GetUsers());

            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var user = _mapper.Map<UserFullResponse>(await _userRepository.GetUserById(userId));
            var friends = _mapper.Map<IEnumerable<UserSimpleResponse>>(new List<User>() { new User() { Id = Guid.NewGuid() } });

            user.Friends = friends;

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] NewUserCreationRequest newUserCreationRequest)
        {
            var newUser = _mapper.Map<User>(newUserCreationRequest);

            await _userRepository.AddUser(newUser);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetUser), new { userId = newUser.Id }, newUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserInfoRequest updateUserInfoRequest)
        {
            var user = _mapper.Map<User>(updateUserInfoRequest);

            _userRepository.UpdateUser(user);
            await _unitOfWork.CompleteAsync();

            return Ok(user);
        }
    }
}