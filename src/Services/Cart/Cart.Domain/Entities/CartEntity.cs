using Cart.Domain.Common;

namespace Cart.Domain.Entities;

public class CartEntity : EntityBase
{
    private string? _userName;

    public string? UserName
    {
        get { return _userName; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Invalid user name");

            _userName = value;
        }
    }

    private List<CartProduct> Products { get; set; } = new();

    public CartEntity(string userName)
    {
        _userName = userName;
    }

    public CartEntity(string userName, List<CartProduct> products)
    {
        UserName = userName;
        Products = products;
    }

    public CartEntity AddProduct(string productId, int quantity)
    {
        if (quantity > 0)
        {
            CartProduct cp = new(productId, quantity);
            Products.Add(cp);
        }

        return this;
    }

    public CartEntity RemoveProduct(string productId, int quantity)
    {
        CartProduct? cp = Products.Where(p => p.ProductId == productId).FirstOrDefault();

        if (cp != null)
        {
            if (quantity >= cp.Quantity)
                Products = Products.Where(p => p.ProductId != productId).ToList();

            else
                cp.Quantity -= quantity;
        }

        return this;
    }

    public CartEntity Checkout()
    {
        Products = new();
        return this;
    }
}
