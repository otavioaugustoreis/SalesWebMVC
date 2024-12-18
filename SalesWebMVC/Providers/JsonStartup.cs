using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace SalesWebMVC.Providers
{
    //obs: Classes que contém métodos de extensão precisam ser estáticos!
    public static class JsonStartup
    {
        public static IServiceCollection AddConfigurationJson(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            });

            return services;
        }
    }
}
