using SalesWebMVC.Data.Entity;

namespace SalesWebMVC._2___Domain.Filters
{
    public class SalesRecordsFilter
    {
        public  string  DsNome { get; set; }
        public DateTime? maxDate { get; set; }
        public DateTime? minDate  { get; set; }
        public SellerEntity Seller { get; set; }
    }
}
