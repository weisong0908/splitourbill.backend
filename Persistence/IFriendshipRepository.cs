using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using splitourbill_backend.Models.DomainModels;

namespace splitourbill_backend.Persistence
{
    public interface IFriendshipRepository
    {
        Task<Friendship> GetFriendship(Guid friendshipId);
        Task<IEnumerable<Friendship>> GetFriendshipsByUserId(Guid userId);
        Task<IEnumerable<Friendship>> GetPendingFriendRequestsByRequesteeId(Guid requesteeId);
        Task CreateNewFriendship(Friendship friendship);
    }
}