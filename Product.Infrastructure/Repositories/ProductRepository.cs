using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using Product.Application.Common.Interfaces;
using Product.Domain.Entities;
using Product.Infrastructure.Persistence;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository, IReadProductRepository
    {
        private readonly MongoDbContext _context;

        public ProductRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Domain.Entities.Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Domain.Entities.Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.InsertOneAsync(product, options: null, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(Domain.Entities.Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _context.Products.DeleteOneAsync(p => p.Id == id, cancellationToken);
        }
    }
}
