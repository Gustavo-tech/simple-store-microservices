using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages;

public class CartCheckoutEvent : BaseEvent
{
    public string Username { get; private set; }
    public CartItem[] Products { get; private set; }

    public CartCheckoutEvent(string username, CartItem[] products)
    {
        Username = username;
        Products = products;
    }
}

public class CartItem
{
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }

    public CartItem(int productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}
