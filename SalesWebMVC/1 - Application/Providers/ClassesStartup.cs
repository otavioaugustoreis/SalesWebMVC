using Microsoft.AspNetCore.Mvc.ViewComponents;
using SalesWebMVC._2___Domain.Interfaces;
using SalesWebMVC._2___Domain.Services;
using SalesWebMVC.Data;
using SalesWebMVC.Data.Entity;
using SalesWebMVC.Data.Repositories;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Repositories;
using SalesWebMVC.Models.Services;
using SalesWebMVC.UnitOfWork;

namespace SalesWebMVC.Providers
{
    public static class ClassesStartup
    {
        public static IServiceCollection AddDIPScoppedClasse(this IServiceCollection services)
        {
            services.AddScoped<SeedingService>();
            services.AddScoped<AppDbContext>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<ISalesRecordService, SalesRecordService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWorkClass>();
            services.AddScoped<IProductService, ProductService>();


            return services;
        }
        public static IServiceCollection AddDIPSingletonClasse(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDIPTransientClasse(this IServiceCollection services)
        {
            return services;
        }
    }
}
