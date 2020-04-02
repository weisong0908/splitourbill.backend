using System;
using System.Collections.Generic;
using splitourbill_backend.Models.DomainModels;

namespace splitourbill_backend.Models.ResponseModels
{
    public class BillResponse
    {
        public Guid Id { get; set; }
        public UserSimpleResponse Initiator { get; set; }
        public string BillPurpose { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public DateTime DateTime { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<BillSharingResponse> BillSharings { get; set; }
    }
}