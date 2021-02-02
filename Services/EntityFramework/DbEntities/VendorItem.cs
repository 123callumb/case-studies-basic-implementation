using System;
using System.Collections.Generic;

#nullable disable

namespace Services.EntityFramework.DbEntities
{
    public partial class VendorItem
    {
        public VendorItem()
        {
            Quotes = new HashSet<Quote>();
        }

        public int ItemId { get; set; }
        public int? VendorId { get; set; }
        public string ItemName { get; set; }
        public string ItemImageUrl { get; set; }
        public string ItemDescription { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
