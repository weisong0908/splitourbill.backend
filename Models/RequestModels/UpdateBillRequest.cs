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
        public UserSimpleResponse Initiator { get; set; }
        public string BillPurpose { get; set; }
        [JsonConverter(typeof(StringToDecimalConverter))]
        public decimal TotalAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public DateTime DateTime { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<BillSharingResponse> BillSharings { get; set; }
    }
}