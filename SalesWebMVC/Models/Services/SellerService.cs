using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Data.Entity;
using SalesWebMVC.Data.Repositories;
using SalesWebMVC.Models.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace SalesWebMVC.Models.Services
{
    public class SellerService : Repository<SellerEntity>, ISellerService
    {
        public SellerService(AppDbContext context) : base(context)
        {
        }

        public SellerEntity? loadingDepartament(Expression<Func<SellerEntity, bool>> predicate)
        {
            //O include trás no banco tambem a classe(tabela) que eu colocar dentro dele, ou seja, busquei a classe Department
            return _context.Seller.Include(obj => obj.Department)
                                        .FirstOrDefault(predicate);
        }

        public async Task<List<SellerEntity>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        } 
    }
}
