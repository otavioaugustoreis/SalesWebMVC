using SalesWebMVC._3___Data.Entity;
using SalesWebMVC.Data.Enums;
using SalesWebMVC.Data.Repositories;

namespace SalesWebMVC._2___Domain.Interfaces
{
    public interface ISaleProductService : IRepository<SalesProductEntity>
    {
        Task GenerateSale(int idCliente, int idProduto, SaleStatus saleStatus);

    }
}
