using SalesWebMVC._2___Domain.Interfaces;
using SalesWebMVC.Models.Repositories;

namespace SalesWebMVC.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDepartmentService _Department { get; }
        ISalesRecordService _Sales { get; }
        ISellerService _Seller { get; }
        IProductService _Product { get;  }
        void Commit();
    }
}
