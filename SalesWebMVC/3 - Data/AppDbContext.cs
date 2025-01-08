using Microsoft.EntityFrameworkCore;
using SalesWebMVC._3___Data.Entity;
using SalesWebMVC.Data.Entity;

namespace SalesWebMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options)
        {
        }

        public DbSet<SellerEntity> Seller{ get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<SalesRecordEntity> Sales { get; set; }

        public DbSet<ProductEntity> Product { get; set; }

        public DbSet<SalesProductEntity> SalesProduct { get; set; }


        //Criando relações
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                    .HasMany(p => p.SalesProductsList)
                    .WithOne(p => p.Product)
                    .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<SalesRecordEntity>()
                    .HasMany(p => p.SalesProductsList)
                    .WithOne(p => p.SalesRecord)
                    .HasForeignKey(p => p.SalesRecordId);

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
