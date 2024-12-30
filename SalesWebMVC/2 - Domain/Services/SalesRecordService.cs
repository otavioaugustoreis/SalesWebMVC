using Microsoft.EntityFrameworkCore;
using SalesWebMVC._2___Domain.Filters;
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

        public async Task<List<SalesRecordEntity>> FindByDate(  DateTime? minDate, DateTime? maxDate)
        {

            return await _context.Sales
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .Where(sr => sr.DhInclusao >= minDate.Value && sr.DhInclusao <= maxDate.Value)
                .ToListAsync();
        }

        //Método agrupado
        public async Task<List<IGrouping<DepartmentEntity, SalesRecordEntity>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue || !maxDate.HasValue)
            {
                
            }

                return await _context.Sales
                 .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                //Ordem decrecente 
                .OrderByDescending(x => x.DhInclusao)
                // O retorno de um groupBy é uma Lista IGrouping               
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }

        public async Task<List<SalesRecordEntity>> GetSalesRecordsFilter(SalesRecordsFilter salesRecordsFilter)
        {
            var minDate = salesRecordsFilter.minDate;
            var maxDate = salesRecordsFilter.maxDate;
            var name    = salesRecordsFilter.DsNome ;

            var consulta = _context.Sales.AsQueryable();

            consulta =  consulta
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .Where(sr => sr.DhInclusao >= minDate.Value && 
                             sr.DhInclusao <= maxDate.Value &&
                             (string.IsNullOrEmpty(name) || sr.Seller.DsNome.Contains(name)));

            return await consulta.ToListAsync();
        }
    }
}

