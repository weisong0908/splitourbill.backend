using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using splitourbill_backend.Models.DomainModels;
using splitourbill_backend.Utils;

namespace splitourbill_backend.Persistence
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly BackendDbContext _dbContext;

        public FriendshipRepository(BackendDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Friendship>> GetFriendshipsByUserId(Guid userId)
        {
            return await _dbContext.Friendships
                .Where(f => f.Status == Constants.RelationshipStatuses.Accepted)
                .Where(f => f.Requestor == userId || f.Requestee == userId).ToListAsync();
        }
    }
}