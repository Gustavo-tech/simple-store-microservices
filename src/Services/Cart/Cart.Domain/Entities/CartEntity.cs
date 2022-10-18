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

    public List<CartProduct> Products { get; private set; } = new();

    public CartEntity()
    {
    }

    public CartEntity(string? userName)
    {
        UserName = userName;
    }

    public CartEntity(string userName, List<CartProduct> products)
    {
        UserName = userName;
        Products = products?.Count > 0 ? products : new();
    }

    public CartEntity AddProduct(string productId, int quantity)
    {
        if (quantity > 0)
        {
            if (Products.Any(x => x.ProductId == productId))
            {
                foreach (CartProduct p in Products)
                {
                    if (p.ProductId == productId)
                        p.Quantity += quantity;
                }
            }

            else
            {
                CartProduct cp = new(productId, quantity);
                Products.Add(cp);
            }
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
