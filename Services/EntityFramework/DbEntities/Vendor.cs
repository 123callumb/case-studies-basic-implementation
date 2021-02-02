using System;
using System.Collections.Generic;

#nullable disable

namespace Services.EntityFramework.DbEntities
{
    public partial class Vendor
    {
        public Vendor()
        {
            VendorItems = new HashSet<VendorItem>();
            VendorUsers = new HashSet<VendorUser>();
        }

        public int VendorId { get; set; }
        public string VendorName { get; set; }

        public virtual ICollection<VendorItem> VendorItems { get; set; }
        public virtual ICollection<VendorUser> VendorUsers { get; set; }
    }
}
