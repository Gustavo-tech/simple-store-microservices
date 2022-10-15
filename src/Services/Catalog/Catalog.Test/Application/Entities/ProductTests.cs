using Catalog.Domain.Entities;

namespace Catalog.Test.Application.Entities;

public class ProductTests
{
    [Test]
    [TestCase("")]
    [TestCase(null)]
    [TestCase("   ")]
    public void InstantiateProduct_TitleIsInvalid_ThrowAnException(string title)
    {
        Assert.That(() => new Product(title, "", 10, 1), Throws.Exception);
    }

    [Test]
    [TestCase(-3)]
    [TestCase(-10)]
    [TestCase(-1)]
    public void InstantiateProduct_QuantityIsLessThanZero_ThrowAnException(int quantity)
    {
        Assert.That(() => new Product("Product", "", quantity, 1), Throws.Exception);
    }

    [Test]
    [TestCase(-3)]
    [TestCase(-10)]
    [TestCase(-1)]
    public void InstantiateProduct_PriceIsLessThanZero_ThrowAnException(decimal price)
    {
        Assert.That(() => new Product("Product", "", 1, price), Throws.Exception);
    }
}
