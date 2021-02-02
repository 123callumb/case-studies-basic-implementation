using System;
using System.Collections.Generic;

#nullable disable

namespace Services.EntityFramework.DbEntities
{
    public partial class QuoteResponse
    {
        public int QuoteResponseId { get; set; }
        public int QuoteId { get; set; }
        public int QuoteStatusId { get; set; }
        public DateTime ResponseDate { get; set; }
        public string ReponseText { get; set; }
        public float Quote { get; set; }

        public virtual Quote QuoteNavigation { get; set; }
        public virtual QuoteStatus QuoteStatus { get; set; }
    }
}
