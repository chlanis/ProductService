using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
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
        }

        public IMongoCollection<Domain.Entities.Product> Products => _database.GetCollection<Domain.Entities.Product>("Products");
    }
}
