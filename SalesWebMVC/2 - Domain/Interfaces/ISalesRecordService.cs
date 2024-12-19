using SalesWebMVC.Data.Entity;
using SalesWebMVC.Data.Repositories;
using SalesWebMVC.Models.Services;

namespace SalesWebMVC.Models.Repositories
{
    public interface ISalesRecordService : IRepository<SalesRecordEntity>
    {
         Task<List<SalesRecordEntity>> FindByDate(DateTime? minDate, DateTime? maxDate);
         Task<List<IGrouping<DepartmentEntity, SalesRecordEntity>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate);
    }
}
