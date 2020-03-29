using System.Collections.Generic;
using System.Threading.Tasks;
using splitourbill_backend.Models.DomainModels;

namespace splitourbill_backend.Persistence
{
    public interface IBillRepository
    {
        Task<IEnumerable<BillPurpose>> GetBillPurposes();
    }
}