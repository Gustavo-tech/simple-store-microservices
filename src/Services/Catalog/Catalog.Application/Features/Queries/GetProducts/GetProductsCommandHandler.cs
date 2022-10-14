using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Queries.GetProducts;

public class GetProductsCommandHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepo;
    private readonly ILogger<GetProductsCommandHandler> _logger;

    public GetProductsCommandHandler(IProductRepository productRepo, ILogger<GetProductsCommandHandler> logger)
    {
        _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _productRepo.GetProductsAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }
}
