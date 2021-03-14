using System;
using System.Collections.Generic;

#nullable disable

namespace Services.EntityFramework.DbEntities
{
    public partial class User
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CompanyEmail { get; set; }
        public DateTime? Dob { get; set; }
        public string PasswordHash { get; set; }

        public virtual Role Role { get; set; }
    }
}
