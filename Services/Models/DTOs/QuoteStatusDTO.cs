using Services.EntityFramework.DbEntities;
using Services.Models.Enums;
using System;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class QuoteStatusDTO
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public QuoteStatusEnum AsEnum => (QuoteStatusEnum)StatusID;
        public string Colour { get; set; }
        public static Expression<Func<QuoteStatus, QuoteStatusDTO>> MapToDTO = s => new QuoteStatusDTO()
        {
            StatusID = s.QuoteStatusId,
            StatusName = s.StatusName,
            Colour = s.Colour
        };
    }
}
