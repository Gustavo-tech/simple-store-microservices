using Catalog.Application.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepo;
    private readonly ILogger<DeleteProductCommandHandler> _logger;

    public DeleteProductCommandHandler(IProductRepository productRepo, ILogger<DeleteProductCommandHandler> logger)
    {
        _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _productRepo.DeleteProductAsync(request.Id);

            return Unit.Value;
        }
        catch (Exception e)
        {
            _logger.LogError($"An error happened while deleting a product, {e.Message}");
            throw;
        }
    }
}
