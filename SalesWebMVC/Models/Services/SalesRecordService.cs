using SalesWebMVC.Data;
using SalesWebMVC.Data.Entity;
using SalesWebMVC.Data.Repositories;
using SalesWebMVC.Models.Repositories;

namespace SalesWebMVC.Models.Services
{
    public class SalesRecordService : Repository<SalesRecordEntity>, ISalesRecordService
    {
        public SalesRecordService(AppDbContext context) : base(context)
        {
        }
        }
    }

