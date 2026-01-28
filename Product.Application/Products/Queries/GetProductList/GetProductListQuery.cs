using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Product.Application.Common.Interfaces;
using Product.Application.Products.DTOs;

namespace Product.Application.Products.Queries.GetProductList
{
    public record GetProductListQuery() : IRequest<IEnumerable<ProductDto>>;

    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductDto>>
    {
        private readonly IReadProductRepository _repository;

        public GetProductListQueryHandler(IReadProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync(cancellationToken);

            return products.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                SKU = product.SKU,
                Price = product.Price,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            });
        }
    }
}
