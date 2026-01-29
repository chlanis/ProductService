using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Product.Application.Common.Interfaces;
using Product.Infrastructure.Persistence;
using Product.Infrastructure.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Product.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure MongoDB Serialization
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));

            services.AddSingleton<MongoDbContext>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<IProductRepository>(sp => sp.GetRequiredService<ProductRepository>());
            services.AddScoped<IReadProductRepository>(sp => sp.GetRequiredService<ProductRepository>());
            
            return services;
        }
    }
}
