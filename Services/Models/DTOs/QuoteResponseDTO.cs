using Services.EntityFramework.DbEntities;
using System;
using System.Linq.Expressions;

namespace Services.Models.DTOs
{
    public class QuoteResponseDTO
    {
        public int QuoteResponseId { get; set; }
        public int QuoteId { get; set; }
        public QuoteStatusDTO Status { get; set; }
        public DateTime ResponseDate { get; set; }
        public string ReponseText { get; set; }
        public float QuotePrice { get; set; }

        public static Expression<Func<QuoteResponse, QuoteResponseDTO>> MapToDTO = s => new QuoteResponseDTO
        {
            QuoteId = s.QuoteId,
            QuotePrice = s.Quote,
            QuoteResponseId = s.QuoteResponseId,
            ReponseText = s.ReponseText,
            ResponseDate = s.ResponseDate,
            Status = QuoteStatusDTO.MapToDTO.Compile().Invoke(s.QuoteStatus)
        };
    }
}
