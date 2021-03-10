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
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PasswordHash { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
