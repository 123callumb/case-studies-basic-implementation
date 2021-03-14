using Services.EntityFramework.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class QuoteDTO
    {
        public int QuoteID { get; set; }
        public VendorItemDTO VendorItem { get; set; }
        public DateTime QuoteDate { get; set; }
        public List<QuoteResponseDTO> Responses { get; set; }
        public int QuantityRequested { get; set; }

        public static Expression<Func<Quote, QuoteDTO>> MapToDTO = s => new QuoteDTO()
        {
            QuoteID = s.QuoteId,
            QuantityRequested = s.QuantityRequested,
            QuoteDate = s.QuoteDate,
            VendorItem = new VendorItemDTO
            {
                ItemDescription = s.VendorItem.ItemDescription,
                ItemID = s.VendorItem.ItemId,
                ItemImageURL = s.VendorItem.ItemImageUrl,
                ItemName = s.VendorItem.ItemName,
                VendorID = s.VendorItem.VendorId,
                VendorName = s.VendorItem.Vendor.VendorName
            },
            Responses = s.QuoteResponses.AsQueryable().Select(QuoteResponseDTO.MapToDTO).OrderBy(x => x.ResponseDate).ToList()
        };
    }
}
