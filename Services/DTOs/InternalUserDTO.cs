using Services.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Services.DTOs
{
    public class InternalUserDTO
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CompanyEmail { get; set; }

        public static Expression<Func<User, InternalUserDTO>> MapToDTO = m => new InternalUserDTO()
        {
            CompanyEmail = m.CompanyEmail,
            Firstname = m.Firstname,
            Lastname = m.Lastname,
            RoleID = m.RoleId,
            UserID = m.UserId
        };
    }
}
