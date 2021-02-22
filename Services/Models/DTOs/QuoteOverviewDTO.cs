using Services.EntityFramework.DbEntities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class QuoteOverviewDTO
    {
        public int QuoteID { get; set; }
        public VendorItemDTO VendorItem { get; set; }
        public DateTime QuoteDate { get; set; }
        public QuoteStatusDTO LatestStatus { get; set; }
        public int QuantityRequested { get; set; }

        public static Expression<Func<Quote, QuoteOverviewDTO>> MapToDTO = s => new QuoteOverviewDTO()
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
            LatestStatus = s.QuoteResponses.Any() ? QuoteStatusDTO.MapToDTO.Compile().Invoke(s.QuoteResponses.OrderByDescending(o => o.QuoteResponseId).FirstOrDefault().QuoteStatus) : null
        };
    }
}
