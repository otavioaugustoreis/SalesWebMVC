using NuGet.Protocol.Core.Types;
using SalesWebMVC.Data;
using SalesWebMVC.Data.Entity;
using SalesWebMVC.Data.Repositories;
using SalesWebMVC.Models.Repositories;

namespace SalesWebMVC.Models.Services
{
    public class DepartmentService : Repository<DepartmentEntity>, IDepartmentService
    {
        public DepartmentService(AppDbContext context) : base(context)
        {
        }
    }
}
