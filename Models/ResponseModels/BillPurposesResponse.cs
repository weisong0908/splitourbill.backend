using System.Collections.Generic;

namespace splitourbill_backend.Models.ResponseModels
{
    public class BillPurposesResponse
    {
        public string CategoryName { get; set; }
        public IEnumerable<string> Options { get; set; }

        public BillPurposesResponse(string categoryName, IEnumerable<string> options)
        {
            CategoryName = categoryName;
            Options = options;
        }
    }
}