using Services.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class QuoteDTO
    {
        public int QuoteID { get; set; }
        public VendorItemDTO VendorItem { get; set; }
        public DateTime QuoteDate { get; set; }
        public int QuantityRequested { get; set; }
        public static Expression<Func<Quote, QuoteDTO>> MapToDTO = s => new QuoteDTO()
        {
            QuoteID = s.QuoteId,
            QuantityRequested = s.QuantityRequested,
            QuoteDate = s.QuoteDate,
            VendorItem = VendorItemDTO.MapToDTO.Compile().Invoke(s.VendorItem)
        };
    }
}
