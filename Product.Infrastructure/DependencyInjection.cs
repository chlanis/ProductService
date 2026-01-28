using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Product.Application.Common.Interfaces;
using Product.Infrastructure.Persistence;
using Product.Infrastructure.Repositories;

namespace Product.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MongoDbContext>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<IProductRepository>(sp => sp.GetRequiredService<ProductRepository>());
            services.AddScoped<IReadProductRepository>(sp => sp.GetRequiredService<ProductRepository>());
            
            return services;
        }
    }
}
