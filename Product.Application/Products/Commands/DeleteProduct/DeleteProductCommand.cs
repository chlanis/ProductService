using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Product.Application.Common.Interfaces;

namespace Product.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : IRequest;

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
