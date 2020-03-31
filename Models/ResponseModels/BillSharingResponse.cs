using System;

namespace splitourbill_backend.Models.ResponseModels
{
    public class BillSharingResponse
    {
        public Guid Id { get; set; }
        public UserSimpleResponse Sharer { get; set; }
        public decimal Amount { get; set; }
    }
}