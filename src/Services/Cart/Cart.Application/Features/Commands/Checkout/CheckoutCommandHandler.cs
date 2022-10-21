using Cart.Application.Abstractions;
using Cart.Application.Features.Commands.CreateCart;
using Cart.Domain.Entities;
using EventBus.Messages;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Application.Features.Commands.Checkout;

public class CheckoutCommandHandler : IRequestHandler<CheckouCommand, CartEntity>
{
    private readonly ICartRepository _cartRepository;
    private readonly ILogger<CreateCartCommandHandler> _logger;
    private readonly IBus _bus;

    public CheckoutCommandHandler(ICartRepository cartRepository, ILogger<CreateCartCommandHandler> logger, IBus bus)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
    }

    public async Task<CartEntity> Handle(CheckouCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CartEntity cart = await _cartRepository.GetCartAsync(request.Username);
            CartItem[] items = new CartItem[cart.Products.Count];

            for (int i = 0; i < cart.Products.Count; i++)
            {
                items[i] = new(cart.Products[i].ProductId, cart.Products[i].Quantity);
            }

            cart.Checkout();

            await _cartRepository.UpdateCartAsync(cart);
            await _bus.Publish(new CartCheckoutEvent(request.Username, items));

            return cart;
        }
        catch (Exception e)
        {
            _logger.LogError($"An error ocurred while checking out, {e.Message}");
            throw;
        }
    }
}
