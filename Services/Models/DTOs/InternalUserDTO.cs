using Services.Models.Abstract;
using Services.EntityFramework.DbEntities;
using Services.Models.Enums;
using System;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class InternalUserDTO : AbstractUser
    {
        public int RoleID { get; set; }

        public static Expression<Func<User, InternalUserDTO>> MapToDTO = m => new InternalUserDTO()
        {
            Email = m.CompanyEmail,
            Firstname = m.Firstname,
            Lastname = m.Lastname,
            RoleID = m.RoleId,
            UserID = m.UserId,
            UserType = UserTypeEnum.INTERNAL,
            PasswordHash = m.PasswordHash
        };
    }
}
