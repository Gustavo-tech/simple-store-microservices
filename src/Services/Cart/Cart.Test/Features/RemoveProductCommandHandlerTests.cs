using Cart.Application.Abstractions;
using Cart.Application.Features.Commands.CreateCart;
using Cart.Application.Features.Commands.RemoveProduct;
using Cart.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace Cart.Test.Features;
public class RemoveProductCommandHandlerTests
{
    private Mock<ICartRepository> _mockcartRepository = new();
    private Mock<ILogger<CreateCartCommandHandler>> _mockLogger = new();
    private readonly RemoveProductCommandHandler _commandHandler;

    public RemoveProductCommandHandlerTests()
    {
        _commandHandler = new(_mockcartRepository.Object, _mockLogger.Object);
    }

    [SetUp]
    public void SetUp()
    {
        List<CartProduct> cartProducts = new()
        {
            new CartProduct(1, 10),
            new CartProduct(2, 15),
            new CartProduct(3, 20),
        };

        _mockcartRepository.Setup(x => x.GetCartAsync(It.IsAny<string>()))
            .ReturnsAsync(new CartEntity("Gustavo", cartProducts));
    }

    [Test]
    [TestCase(1, 5, 5)]
    [TestCase(2, 12, 3)]
    [TestCase(3, 10, 10)]
    public void TestHandle_UserNameIsValid_RemoveProducts(int productId, int quantityToRemove, int quantityExpected)
    {
        RemoveProductCommand command = new() { ProductId = productId, Username = "Gustavo", Quantity = quantityToRemove };
        CancellationTokenSource source = new();

        Assert.DoesNotThrowAsync(() => _commandHandler.Handle(command, source.Token));
        _mockcartRepository.Verify(x => x.GetCartAsync(It.IsAny<string>()), Times.AtMost(3));
        _mockcartRepository.Verify(x => x.UpdateCartAsync(It.Is<CartEntity>(x =>
            x.Products.FirstOrDefault(x => x.ProductId == productId).Quantity == quantityExpected)), Times.AtMost(3));
    }
}
