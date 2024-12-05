using SalesWebMVC.Data.Entity;
using SalesWebMVC.Data.Repositories;
using System.Linq.Expressions;

namespace SalesWebMVC.Models.Repositories
{
    public interface ISellerService : IRepository<SellerEntity>
    {
        SellerEntity? loadingDepartament(Expression<Func<SellerEntity, bool>> predicate);
    }
}
