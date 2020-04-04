using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using splitourbill_backend.Models.DomainModels;

namespace splitourbill_backend.Persistence
{
    public interface IBillRepository
    {
        Task<IEnumerable<BillPurpose>> GetBillPurposes();
        Task<Bill> GetBillByBillId(Guid billId);
        Task<IEnumerable<BillSharing>> GetBillSharingsByBillId(Guid billId);
        void UpdateBill(Bill bill);

    }
}