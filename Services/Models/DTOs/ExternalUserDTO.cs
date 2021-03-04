using Services.Models.Abstract;
using Services.EntityFramework.DbEntities;
using Services.Models.Enums;
using System;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class ExternalUserDTO : AbstractUser
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }

        public static Expression<Func<VendorUser, ExternalUserDTO>> MapToDTO = m => new ExternalUserDTO()
        {
            Email= m.Email,
            UserID = m.VendorUserId,
            VendorID = m.VendorId,
            UserType = UserTypeEnum.EXTERNAL,
            VendorName = m.Vendor.VendorName,
            Firstname = m.Firstname,
            Lastname = m.Lastname,
            PasswordHash = m.PasswordHash
        };
    }
}
