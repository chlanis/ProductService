using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Product.Domain.Entities;

namespace Product.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<Domain.Entities.Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Domain.Entities.Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Domain.Entities.Product product, CancellationToken cancellationToken = default);
        Task UpdateAsync(Domain.Entities.Product product, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }

    public interface IReadProductRepository
    {
        Task<Domain.Entities.Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Domain.Entities.Product>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
