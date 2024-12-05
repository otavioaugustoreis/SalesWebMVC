using SalesWebMVC.Data.Entity;
using SalesWebMVC.Data.Repositories;
using SalesWebMVC.Models.Services;

namespace SalesWebMVC.Models.Repositories
{
    public interface ISalesRecordService : IRepository<SalesRecordEntity>
    {
    }
}
