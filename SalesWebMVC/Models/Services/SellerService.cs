using SalesWebMVC.Data;
using SalesWebMVC.Data.Entity;
using SalesWebMVC.Data.Repositories;
using SalesWebMVC.Models.Repositories;

namespace SalesWebMVC.Models.Services
{
    public class SellerService : Repository<SellerEntity>, ISellerService
    {
        public SellerService(AppDbContext context) : base(context)
        {
        }
    }
}
