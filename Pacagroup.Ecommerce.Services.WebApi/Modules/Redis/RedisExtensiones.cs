namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Redis
{
    public static class RedisExtensiones
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
            });
            return services;
        }
    }
}
