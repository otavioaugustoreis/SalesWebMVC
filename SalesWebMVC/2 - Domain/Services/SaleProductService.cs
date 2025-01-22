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

        //Está dando erro neste método ao executar a procedure 
        public async  Task GenerateSale(int idCliente, int idProduto, SaleStatus saleStatus)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"EXEC {storedProcedure} @Param1 = {idProduto}, @Param2 = {idCliente}, @Param3 = {(int)saleStatus}"
                );

                await transaction.CommitAsync(); // Persiste as mudanças
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(); // Reverte em caso de erro
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
