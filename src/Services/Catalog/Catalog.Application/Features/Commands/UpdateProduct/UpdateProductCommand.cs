using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public UpdateProductCommand(int id, string title, string description, int quantity, decimal price)
    {
        Id = id;
        Title = title;
        Description = description;
        Quantity = quantity;
        Price = price;
    }
}
