using System;

namespace splitourbill_backend.Models.DomainModels
{
    public class BillSharing
    {
        public Guid Id { get; set; }
        public Guid SharerId { get; set; }
        public decimal Amount { get; set; }
        public Guid BillId { get; set; }
    }
}