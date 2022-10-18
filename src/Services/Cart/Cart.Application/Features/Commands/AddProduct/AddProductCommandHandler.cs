using Cart.Application.Abstractions;
using Cart.Application.Extensions;
using Cart.Application.Features.Commands.CreateCart;
using Cart.Application.Models;
using Cart.Application.Settings;
using Cart.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;

namespace Cart.Application.Features.Commands.AddProduct;
public class AddProductCommandHandler : IRequestHandler<AddProductCommand, CartEntity>
{
    private readonly ICartRepository _cartRepository;
    private readonly ILogger<CreateCartCommandHandler> _logger;
    private readonly string _catalogUrl;

    public AddProductCommandHandler(ICartRepository cartRepository, ILogger<CreateCartCommandHandler> logger,
        IOptions<ApplicationSettings> options)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _catalogUrl = options.Value.CatalogUrl;
    }

    public async Task<CartEntity> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        using HttpClient client = new();
        client.BaseAddress = new Uri(_catalogUrl);

        HttpResponseMessage response = await client.GetAsync($"product/{request.ProductId}");

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Product not found");

        Product p = await response.ReadAs<Product>();

        if (request.Quantity > p.Quantity)
            throw new Exception("Can't add this quantity of products to the cart");

        CartEntity cart = await _cartRepository.GetCartAsync(request.UserName);
        cart.AddProduct(p.Id, request.Quantity);

        await _cartRepository.UpdateCartAsync(cart);

        return cart;
    }
}
