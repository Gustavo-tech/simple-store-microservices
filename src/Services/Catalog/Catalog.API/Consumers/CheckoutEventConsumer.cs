using Catalog.Application.Abstractions;
using Catalog.Application.Features.Commands.UpdateProduct;
using Catalog.Domain.Entities;
using EventBus.Messages;
using MassTransit;
using MediatR;

namespace Catalog.API.Consumers;

public class CheckoutEventConsumer : IConsumer<CartCheckoutEvent>
{
    private readonly IProductRepository _productRepository;
    private readonly IMediator _mediator;

    public CheckoutEventConsumer(IProductRepository productRepository, IMediator mediator)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task Consume(ConsumeContext<CartCheckoutEvent> context)
    {
        foreach (var product in context.Message.Products)
        {
            Product p = await _productRepository.GetByIdAsync(product.ProductId);
            p.ProductSold(product.Quantity);

            await _mediator.Send(new UpdateProductCommand(p.Id, p.Title, p.Description, p.Quantity, p.Price));
        }
    }
}
