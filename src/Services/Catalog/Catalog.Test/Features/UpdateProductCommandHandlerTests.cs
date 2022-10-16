using Catalog.Application.Abstractions;
using Catalog.Application.Features.Commands.UpdateProduct;
using Catalog.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace Catalog.Test.Features;

public class UpdateProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _productRepoMock = new();
    private readonly Mock<ILogger<UpdateProductCommandHandler>> _loggerMock = new();
    private readonly UpdateProductCommandHandler _commandHandler;

    public UpdateProductCommandHandlerTests()
    {
        _commandHandler = new(_productRepoMock.Object, _loggerMock.Object);
    }

    [Test]
    public async Task TestHandle_CommandIsValid_ShouldCallUpdateProduct()
    {
        UpdateProductCommand command = new(1, "Product", "", 10, 10);
        CancellationTokenSource source = new();

        await _commandHandler.Handle(command, source.Token);
        _productRepoMock.Verify(mock => mock.UpdateProductAsync(It.IsAny<Product>()), Times.Once);
    }
}
