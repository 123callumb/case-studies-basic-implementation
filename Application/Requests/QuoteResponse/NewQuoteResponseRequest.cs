using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Requests.QuoteResponse
{
    public class NewQuoteResponseRequest
    {
        public int QuoteID { get; set; }
        public string ResponseText { get; set; }
        public float QuotePrice { get; set; }
    }
}
