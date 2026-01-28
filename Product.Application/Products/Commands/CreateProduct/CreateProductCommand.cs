using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Product.Application.Common.Interfaces;

namespace Product.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(string Name, string SKU, decimal Price) : IRequest<Guid>;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Domain.Entities.Product.Create(request.Name, request.SKU, request.Price);
            
            await _repository.AddAsync(product, cancellationToken);
            
            return product.Id;
        }
    }
}
