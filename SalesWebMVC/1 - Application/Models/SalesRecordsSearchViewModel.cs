using SalesWebMVC._2___Domain.Filters;
using SalesWebMVC.Data.Entity;

namespace SalesWebMVC._1___Application.Models
{
    public class SalesRecordsSearchViewModel
    {
        public SalesRecordsFilter Filter { get; set; } = new SalesRecordsFilter();
        public IEnumerable<SalesRecordEntity> SalesRecords { get; set; } = new List<SalesRecordEntity>();
    }
}
