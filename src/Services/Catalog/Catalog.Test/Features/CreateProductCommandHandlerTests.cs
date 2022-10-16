using Catalog.Application.Abstractions;
using Catalog.Application.Features.Commands.CreateProduct;
using Catalog.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace Catalog.Test.Features;

public class CreateProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _productRepoMock = new();
    private readonly Mock<ILogger<CreateProductCommandHandler>> _loggerMock = new();
    private readonly CreateProductCommandHandler _commandHandler;

    public CreateProductCommandHandlerTests()
    {
        _commandHandler = new(_productRepoMock.Object, _loggerMock.Object);
    }

    [Test]
    public void TestHandle_CommandIsValid_ShouldNotThrowAnException()
    {
        CreateProductCommand command = new("Product", "", 10, 10);
        CancellationTokenSource source = new();

        Assert.DoesNotThrowAsync(() => _commandHandler.Handle(command, source.Token));
    }

    [Test]
    public async Task TestHandle_CommandIsValid_ShouldCallAddProduct()
    {
        CreateProductCommand command = new("Product", "", 10, 10);
        CancellationTokenSource source = new();

        await _commandHandler.Handle(command, source.Token);
        _productRepoMock.Verify(mock => mock.AddProductAsync(It.IsAny<Product>()), Times.Once);
    }
}
