using SalesWebMVC.Models.Repositories;

namespace SalesWebMVC.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDepartmentService _Department { get; }
        ISalesRecordService _Sales { get; }
        ISellerService _Seller { get; }

        void Commit();
    }
}
