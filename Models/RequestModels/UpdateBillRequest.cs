using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using splitourbill_backend.JsonConverters;
using splitourbill_backend.Models.ResponseModels;

namespace splitourbill_backend.Models.RequestModels
{
    public class UpdateBillRequest
    {
        public Guid Id { get; set; }
        public Guid InitiatorId { get; set; }
        public string BillPurpose { get; set; }
        [JsonConverter(typeof(StringToDecimalConverter))]
        public decimal TotalAmount { get; set; }
        [JsonConverter(typeof(StringToDecimalConverter))]
        public decimal BalanceAmount { get; set; }
        public DateTime DateTime { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<BillSharingRequest> BillSharings { get; set; }
    }
}