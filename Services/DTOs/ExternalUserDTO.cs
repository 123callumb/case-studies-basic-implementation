using Services.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Services.DTOs
{
    public class ExternalUserDTO
    {
        public int UserID { get; set; }
        public int VendorID { get; set; }
        public string Email { get; set; }

        public static Expression<Func<VendorUser, ExternalUserDTO>> MapToDTO = m => new ExternalUserDTO()
        {
            Email= m.Email,
            UserID = m.VendorUserId,
            VendorID = m.VendorId
        };
    }
}
