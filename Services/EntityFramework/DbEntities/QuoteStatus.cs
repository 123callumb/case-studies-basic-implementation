using System;
using System.Collections.Generic;

#nullable disable

namespace Services.EntityFramework.DbEntities
{
    public partial class QuoteStatus
    {
        public QuoteStatus()
        {
            QuoteResponses = new HashSet<QuoteResponse>();
        }

        public int QuoteStatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<QuoteResponse> QuoteResponses { get; set; }
    }
}
