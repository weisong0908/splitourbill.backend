using System.Threading.Tasks;

namespace splitourbill_backend.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackendDbContext _dbContext;

        public UnitOfWork(BackendDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}