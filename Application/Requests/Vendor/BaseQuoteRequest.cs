namespace Application.Requests.Vendor
{
    public class BaseQuoteRequest
    {
        public int QuoteID { get; set; }
        public bool? IsApproved { get; set; }
    }
}
