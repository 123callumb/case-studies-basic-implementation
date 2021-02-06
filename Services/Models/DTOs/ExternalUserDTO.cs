using Services.DTOs;
using Services.EntityFramework.DbEntities;
using Services.Models.Enums;
using System;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class ExternalUserDTO : IUserDTO
    {
        public int UserID { get; set; }
        public int VendorID { get; set; }
        public string Email { get; set; }
        public UserTypeEnum UserType { get; set; }

        public static Expression<Func<VendorUser, ExternalUserDTO>> MapToDTO = m => new ExternalUserDTO()
        {
            Email= m.Email,
            UserID = m.VendorUserId,
            VendorID = m.VendorId,
            UserType = UserTypeEnum.EXTERNAL
        };
    }
}
