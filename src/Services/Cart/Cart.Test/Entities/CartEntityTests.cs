using Cart.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Test.Entities;

public class CartEntityTests
{
    public CartEntityTests()
    {
    }

    [Test]
    public void TestAddProduct_ProductIsValid_ProductShouldBeAvailableOnTheList()
    {
        CartEntity cart = new("User");

        cart.AddProduct(1, 10);

        Assert.IsTrue(cart.Products[0].ProductId == 1 && cart.Products[0].Quantity == 10);
    }

    [Test]
    public void TestAddProduct_ProductIsInvalid_ShouldNotAddTheProduct()
    {
        CartEntity cart = new("User");

        cart.AddProduct(-1, -1);

        Assert.IsTrue(cart.Products.Count == 0);
    }

    [Test]
    public void TestCheckout_WhenCalled_ProductsShouldBeEmpty()
    {
        CartEntity cart = new("User");

        cart.AddProduct(1, 10);
        cart.Checkout();

        Assert.Zero(cart.Products.Count);
    }

    [Test]
    public void TestRemoveAllProduct_WhenCalled_CartShouldNotContainAnyProductWithIdFromRangeValue([Range(1, 30, 1)] int id)
    {
        CartEntity cart = new("User");

        cart.AddProduct(1, 10);
        cart.AddProduct(id, 10);
        cart.RemoveProduct(id);

        Assert.IsFalse(cart.Products.Any(x => x.ProductId == id));
    }

    [Test]
    public void TestRemoveProduct_WhenCalled_CartShouldContain5ProductsWithId1()
    {
        CartEntity cart = new("User");

        cart.AddProduct(1, 10);
        cart.RemoveProduct(1, 5);

        Assert.That(cart.Products[0].Quantity == 5, Is.True);
    }

    [Test]
    [TestCase("")]
    [TestCase("   ")]
    [TestCase(null)]
    public void TestCartConstructor_UsernameIsInvalid_ShouldThrowAnException(string user)
    {
        Assert.That(() => new CartEntity(user), Throws.Exception);
    }
}
