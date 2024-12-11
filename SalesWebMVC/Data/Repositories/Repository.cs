using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models.Exceptions;
using SalesWebMVC.Patterns;
using System.Data;
using System.Linq.Expressions;

namespace SalesWebMVC.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityPattern
    {

        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public T Delete(T entidade)
        {
            try
            {
                _context.Set<T>().Remove(entidade);
                return entidade;
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T GetId(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }



        public T Post(T entidade)
        {
            _context.Set<T>().Add(entidade);
            return entidade;
        }

        public T Put(T entidade)
        {
            try
            {
                _context.Set<T>().Update(entidade);
                return entidade;
            }
            catch (DBConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
