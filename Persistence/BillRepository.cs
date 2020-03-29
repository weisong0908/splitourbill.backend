using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using splitourbill_backend.Models.DomainModels;

namespace splitourbill_backend.Persistence
{
    public class BillRepository : IBillRepository
    {
        private readonly BackendDbContext _dbContext;

        public BillRepository(BackendDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BillPurpose>> GetBillPurposes()
        {
            return await _dbContext.BillPurposes.ToListAsync();
        }
    }
}