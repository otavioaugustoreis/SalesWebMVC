using SalesWebMVC.Models.DTO;

namespace SalesWebMVC.Providers
{
    public static  class AutoMapperStartup
    {
        public static IServiceCollection AddAutoMapperStartup(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainDTOMappingProfile));

            return services;
        }
    }
}
