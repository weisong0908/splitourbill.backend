using System;
using System.Collections.Generic;

namespace splitourbill_backend.Models.DomainModels
{
    public class Bill
    {
        public Guid Id { get; set; }
        public Guid InitiatorId { get; set; }
        public int BillPurposeId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateTime { get; set; }
        public string Remarks { get; set; }
    }
}