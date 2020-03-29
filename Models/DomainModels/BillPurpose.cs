using System;

namespace splitourbill_backend.Models.DomainModels
{
    public class BillPurpose
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public BillPurpose(string name, string category)
        {
            Name = name;
            Category = category;
        }
    }
}