using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using splitourbill_backend.Models.DomainModels;

namespace splitourbill_backend.Persistence
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task DeleteUserById(Guid id);
        Task<User> GetUserById(Guid id);
        Task<IEnumerable<User>> GetUsers();
        void UpdateUser(User user);
    }
}