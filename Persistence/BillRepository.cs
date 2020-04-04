using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Bill> GetBillByBillId(Guid billId)
        {
            var bill = await _dbContext.Bills.SingleOrDefaultAsync(b => b.Id == billId);

            return bill;
        }

        public async Task<IEnumerable<BillSharing>> GetBillSharingsByBillId(Guid billId)
        {
            var billSharings = await _dbContext.BillSharings.Where(b => b.BillId == billId).ToListAsync();

            return billSharings;
        }

        public void UpdateBill(Bill bill)
        {
            _dbContext.Bills.Update(bill);
        }

    }
}