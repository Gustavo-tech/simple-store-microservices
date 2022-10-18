using Cart.Application.Abstractions;
using Cart.Application.Settings;
using Cart.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cart.Application.Features.Commands.CreateCart;

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly ILogger<CreateCartCommandHandler> _logger;
    

    public CreateCartCommandHandler(ICartRepository cartRepository, ILogger<CreateCartCommandHandler> logger)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CartEntity entity = new(request.UserName);
            await _cartRepository.AddCartAsync(entity);

            return Unit.Value;
        }
        catch (Exception e)
        {
            _logger.LogError($"An error happened while creating a cart, {e.Message}");
            throw;
        }
    }
}
