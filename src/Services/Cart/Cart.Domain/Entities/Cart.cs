using Cart.Domain.Common;

namespace Cart.Domain.Entities;

public class Cart : EntityBase
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

    public Cart(string userName)
    {
        _userName = userName;
    }

    public Cart(string userName, List<CartProduct> products)
    {
        UserName = userName;
        Products = products;
    }

    public Cart AddProduct(string productId, int quantity)
    {
        if (quantity > 0)
        {
            CartProduct cp = new(productId, quantity);
            Products.Add(cp);
        }

        return this;
    }

    public Cart RemoveProduct(string productId, int quantity)
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
}
