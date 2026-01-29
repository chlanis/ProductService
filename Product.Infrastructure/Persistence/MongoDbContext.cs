using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using Product.Domain.Entities;

namespace Product.Infrastructure.Persistence
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDbSettings:ConnectionString") ?? "mongodb://localhost:27017";
            var databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName") ?? "ProductDb";
            
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

            // Register BsonClassMap
            if (!BsonClassMap.IsClassMapRegistered(typeof(Domain.Entities.Product)))
            {
                BsonClassMap.RegisterClassMap<Domain.Entities.Product>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(p => p.Id);
                });
            }
        }

        public IMongoCollection<Domain.Entities.Product> Products => _database.GetCollection<Domain.Entities.Product>("Products");
    }
}
