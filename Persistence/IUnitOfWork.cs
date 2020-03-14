using System.Threading.Tasks;

namespace splitourbill_backend.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}