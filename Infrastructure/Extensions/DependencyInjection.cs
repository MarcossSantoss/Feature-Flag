using StackExchange.Redis;

namespace FeatureFlag.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>(_ =>
            {
                var redisSection = configuration.GetSection("Redis");

                var options = new ConfigurationOptions
                {
                    User = redisSection["UserName"],
                    Password = redisSection["Password"],
                    AbortOnConnectFail = false
                };

                options.EndPoints.Add(redisSection["ConnectionString"]);

                return ConnectionMultiplexer.Connect(options);
            });

            return services;
        }
    }
}
