using Services.DTOs;
using Services.EntityFramework.DbEntities;
using Services.Models.Enums;
using System;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class InternalUserDTO : IUserDTO
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public UserTypeEnum UserType { get; set; }

        public static Expression<Func<User, InternalUserDTO>> MapToDTO = m => new InternalUserDTO()
        {
            Email = m.CompanyEmail,
            Firstname = m.Firstname,
            Lastname = m.Lastname,
            RoleID = m.RoleId,
            UserID = m.UserId,
            UserType = UserTypeEnum.INTERNAL
        };
    }
}
