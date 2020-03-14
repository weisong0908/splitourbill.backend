using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using splitourbill_backend.Models.DomainModels;

namespace splitourbill_backend.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly BackendDbContext _dbContext;

        public UserRepository(BackendDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();

            return users.OrderBy(u => u.Username);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task DeleteUserById(Guid id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            _dbContext.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
        }
    }
}