using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using System;

namespace SalesWebMVC.Providers
{
    public static  class DataStartup
    {
        public static IServiceCollection AddConectionBD(this IServiceCollection services, string mySqlConnection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseMySql(
                         mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)
                        ));

            return services;
        }
    }
}
