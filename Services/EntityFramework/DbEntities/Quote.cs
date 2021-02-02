using System;
using System.Collections.Generic;

#nullable disable

namespace Services.EntityFramework.DbEntities
{
    public partial class Quote
    {
        public Quote()
        {
            QuoteResponses = new HashSet<QuoteResponse>();
        }

        public int QuoteId { get; set; }
        public int VendorItemId { get; set; }
        public DateTime QuoteDate { get; set; }
        public int QuantityRequested { get; set; }

        public virtual VendorItem VendorItem { get; set; }
        public virtual ICollection<QuoteResponse> QuoteResponses { get; set; }
    }
}
