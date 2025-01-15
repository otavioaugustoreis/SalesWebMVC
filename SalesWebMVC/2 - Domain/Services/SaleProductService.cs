using NuGet.Protocol.Core.Types;
using SalesWebMVC._2___Domain.Interfaces;
using SalesWebMVC._3___Data.Entity;
using SalesWebMVC.Data;
using SalesWebMVC.Data.Repositories;

namespace SalesWebMVC._2___Domain.Services
{
    public class SaleProductService : Repository<SalesProductEntity>, ISaleProductService
    {
        public SaleProductService(AppDbContext context) : base(context)
        {
        }
    }
}
