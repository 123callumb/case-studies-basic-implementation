using Services.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class VendorItemDTO
    {
        public int ItemID { get; set; }
        public int? VendorID { get; set; }
        public string ItemName { get; set; }
        public string ItemImageURL { get; set; }
        public string ItemDescription { get; set; }

        public static Expression<Func<VendorItem, VendorItemDTO>> MapToDTO = m => new VendorItemDTO()
        {
            ItemDescription = m.ItemDescription,
            ItemID = m.ItemId,
            ItemImageURL = m.ItemImageUrl,
            ItemName = m.ItemName,
            VendorID = m.VendorId
        };
    }
}
