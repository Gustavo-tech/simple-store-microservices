using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _productRepo;
    private readonly ILogger<GetProductByIdQueryHandler> _logger;

    public GetProductByIdQueryHandler(IProductRepository productRepo, ILogger<GetProductByIdQueryHandler> logger)
    {
        _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Product p = await _productRepo.GetByIdAsync(request.Id);
            return p;
        }
        catch (Exception e)
        {
            _logger.LogError($"An error happened while getting a product by id, {e.Message}");
            throw;
        }
    }
}
