using System;
using System.Collections.Generic;

#nullable disable

namespace Services.EntityFramework.DbEntities
{
    public partial class VendorUser
    {
        public int VendorUserId { get; set; }
        public int VendorId { get; set; }
        public string Email { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
