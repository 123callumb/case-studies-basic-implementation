
namespace Application.Requests.QuoteRequest
{
    public class VendorQuoteRequest
    {
        public int VendorItemID { get; set; }
        public int Quantity { get; set; }
        public string SearchTerm { get; set; }
    }
}
