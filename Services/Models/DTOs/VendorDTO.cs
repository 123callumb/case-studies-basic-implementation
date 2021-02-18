using Services.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class VendorDTO
    {
        public int VendorID { get; set; }        
        public string VendorName { get; set; }

        public static Expression<Func<Vendor, VendorDTO>> MapToDTO = m => new VendorDTO()
        {
            VendorID = m.VendorId,
            VendorName = m.VendorName
        };
    }
}
