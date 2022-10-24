using Cart.Application.Abstractions;
using Cart.Application.Features.Commands.CreateCart;
using Cart.Application.Features.Commands.RemoveAllProducts;
using Cart.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Test.Features;
public class RemoveAllProductsCommandHandlerTests
{
    private readonly Mock<ICartRepository> _mockcartRepository = new();
    private readonly Mock<ILogger<CreateCartCommandHandler>> _mockLogger = new();
    private readonly RemoveAllProductsCommandHandler _commandHandler;

    public RemoveAllProductsCommandHandlerTests()
    {
        _commandHandler = new(_mockcartRepository.Object, _mockLogger.Object);
    }

    [SetUp]
    public void Setup()
    {
        List<CartProduct> cartProducts = new()
        {
            new CartProduct(1, 10),
            new CartProduct(2, 15),
            new CartProduct(3, 1),
        };

        _mockcartRepository.Setup(x => x.GetCartAsync(It.IsAny<string>()))
            .ReturnsAsync(new CartEntity("Gustavo", cartProducts));
    }

    [Test]
    public void TestHandle_UserNameIsValid_RemoveAllTheProducts()
    {
        RemoveAllProductsCommand command = new() { ProductId = 1, Username = "Gustavo" };
        CancellationTokenSource source = new();

        Assert.DoesNotThrowAsync(() => _commandHandler.Handle(command, source.Token));
        _mockcartRepository.Verify(x => x.GetCartAsync(It.IsAny<string>()), Times.Once);
        _mockcartRepository.Verify(x => x.UpdateCartAsync(It.Is<CartEntity>(x => x.Products.Count == 2)), Times.Once);
    }
}
