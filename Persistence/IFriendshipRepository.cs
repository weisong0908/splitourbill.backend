using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using splitourbill_backend.Models.DomainModels;

namespace splitourbill_backend.Persistence
{
    public interface IFriendshipRepository
    {
        Task<IEnumerable<Friendship>> GetFriendshipsByUserId(Guid userId);
    }
}