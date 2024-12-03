using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options)
        {
        }

        public DbSet<string> teste { get; set; }
    }
}
