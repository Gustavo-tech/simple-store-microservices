using Cart.Application.Abstractions;
using Cart.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Application.Features.Queries.GetCart;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartEntity>
{
    private readonly ICartRepository _cartRepository;
    private readonly ILogger<GetCartQueryHandler> _logger;

    public GetCartQueryHandler(ICartRepository cartRepository, ILogger<GetCartQueryHandler> logger)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task<CartEntity> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return _cartRepository.GetCartAsync(request.UserName);
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred while getting a cart, {e.Message}");
            throw;
        }
    }
}
