using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Core.Types;
using SalesWebMVC._2___Domain.Interfaces;
using SalesWebMVC._3___Data.Entity;
using SalesWebMVC.Data;
using SalesWebMVC.Data.Enums;
using SalesWebMVC.Data.Repositories;

namespace SalesWebMVC._2___Domain.Services
{
    public class SaleProductService : Repository<SalesProductEntity>, ISaleProductService
    {

        private const string storedProcedure =  "SPU_GERARVENDA";
        public SaleProductService(AppDbContext context) : base(context)
        {
        }

        public async  Task<SalesProductEntity> GenerateSale(int idCliente, int idProduto, SaleStatus saleStatus)
        {
            var result = await _context.SalesProduct
                                .FromSqlInterpolated($"EXEC {storedProcedure} @Param1 = {idCliente}, @Param2 = {idProduto}, @Param3 = {((int)saleStatus)}")
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            return result;
        }
    }
}
