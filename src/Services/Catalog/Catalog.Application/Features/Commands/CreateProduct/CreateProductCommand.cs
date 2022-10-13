using MediatR;

namespace Catalog.Application.Features.Commands.CreateProduct;

public class CreateProductCommand : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public CreateProductCommand(string title, string description, int quantity, decimal price)
    {
        Title = title;
        Description = description;
        Quantity = quantity;
        Price = price;
    }
}
