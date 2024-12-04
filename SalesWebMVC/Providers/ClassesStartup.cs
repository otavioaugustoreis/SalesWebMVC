namespace SalesWebMVC.Providers
{
    public static class ClassesStartup
    {
        public static IServiceCollection AddDIPScoppedClasse(this IServiceCollection services)
        {

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
