using Cart.Application.Abstractions;
using Cart.Application.Features.Commands.CreateCart;
using Cart.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Application.Features.Commands.RemoveProduct;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, CartEntity>
{
    private readonly ICartRepository _cartRepository;
    private readonly ILogger<CreateCartCommandHandler> _logger;

    public RemoveProductCommandHandler(ICartRepository cartRepository, ILogger<CreateCartCommandHandler> logger)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CartEntity?> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        CartEntity entity = await _cartRepository.GetCartAsync(request.Username);

        if (entity is not null)
        {
            entity.RemoveProduct(request.ProductId, request.Quantity);
            await _cartRepository.UpdateCartAsync(entity);
        }

        return entity;
    }
}
