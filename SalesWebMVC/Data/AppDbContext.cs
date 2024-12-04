using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data.Entity;

namespace SalesWebMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options)
        {
        }

        //Adicionando as classes que serão usadas pelo EF 
        public DbSet<SellerEntity> sellerEntities { get; set; }
        public DbSet<DepartmentEntity> departmentEntities { get; set; }
        public DbSet<SalesRecordEntity> salesRecordEntities { get; set; }

        //Criando relações
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SellerEntity>()
                .HasMany(p => p.SalesRecords)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.FkSeller);

            modelBuilder.Entity<SellerEntity>()
                .HasOne(p => p.Department)
                .WithMany(p => p.ListSeller)
                .HasForeignKey(p => p.FkDepartamento);
               
            base.OnModelCreating(modelBuilder);
        }

    }
}
