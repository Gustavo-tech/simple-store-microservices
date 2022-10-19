using Cart.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Cart.Application.Features.Commands.RemoveProduct;

public class RemoveProductCommand : IRequest<CartEntity>
{
    [Required(AllowEmptyStrings = false)]
    public int ProductId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string? Username { get; set; }

    [Range(0, int.MaxValue)] 
    public int Quantity { get; set; }
}
