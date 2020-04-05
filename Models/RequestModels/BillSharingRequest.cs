using System;
using System.Text.Json.Serialization;
using splitourbill_backend.JsonConverters;
using splitourbill_backend.Models.ResponseModels;

namespace splitourbill_backend.Models.RequestModels
{
    public class BillSharingRequest
    {
        public Guid Id { get; set; }
        public UserSimpleResponse Sharer { get; set; }
        [JsonConverter(typeof(StringToDecimalConverter))]
        public decimal Amount { get; set; }
    }
}