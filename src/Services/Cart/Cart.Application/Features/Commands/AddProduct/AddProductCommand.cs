using Cart.Domain.Entities;
using MediatR;

namespace Cart.Application.Features.Commands.AddProduct;

public class AddProductCommand : IRequest<CartEntity>
{
    public string UserName { get; private set; }
    public string ProductId { get; private set; }
    public int Quantity { get; private set; }

    public AddProductCommand(string userName, string productId, int quantity)
    {
        UserName = userName;
        ProductId = productId;
        Quantity = quantity;
    }
}
