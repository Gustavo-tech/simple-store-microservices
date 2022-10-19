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

namespace Cart.Application.Features.Commands.RemoveAllProducts;

public class RemoveAllProductsCommandHandler : IRequestHandler<RemoveAllProductsCommand, CartEntity>
{
    private readonly ICartRepository _cartRepository;
    private readonly ILogger<CreateCartCommandHandler> _logger;

    public RemoveAllProductsCommandHandler(ICartRepository cartRepository, ILogger<CreateCartCommandHandler> logger)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CartEntity?> Handle(RemoveAllProductsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CartEntity cart = await _cartRepository.GetCartAsync(request.Username);

            if (cart is not null)
            {
                cart.RemoveProduct(request.ProductId);
                await _cartRepository.UpdateCartAsync(cart);
            }

            return cart;
        }
        catch (Exception e)
        {
            _logger.LogError($"An error happened while removing all the products, {e.Message}");
            throw;
        }
    }
}
