using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Product.Application.Common.Interfaces;

namespace Product.Application.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, string SKU, decimal Price, bool IsActive) : IRequest;

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (product == null)
            {
                throw new Exception($"Product with ID {request.Id} not found.");
            }

            product.Update(request.Name, request.SKU, request.Price, request.IsActive);

            await _repository.UpdateAsync(product, cancellationToken);
        }
    }
}
