using Catalog.Application.Abstractions;
using Catalog.Application.Features.Commands.DeleteProduct;
using Microsoft.Extensions.Logging;
using Moq;

namespace Catalog.Test.Features;

public class DeleteProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _productRepoMock = new();
    private readonly Mock<ILogger<DeleteProductCommandHandler>> _loggerMock = new();
    private readonly DeleteProductCommandHandler _commandHandler;

    public DeleteProductCommandHandlerTests()
    {
        _commandHandler = new(_productRepoMock.Object, _loggerMock.Object);
    }

    [Test]
    public async Task TestHandle_CommandIsValid_ShouldCallDeleteProduct()
    {
        DeleteProductCommand command = new(1);
        CancellationTokenSource source = new();

        await _commandHandler.Handle(command, source.Token);
        _productRepoMock.Verify(mock => mock.DeleteProductAsync(1), Times.Once);
    }
}
