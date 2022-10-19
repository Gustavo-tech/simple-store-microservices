using Cart.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Cart.Application.Features.Commands.RemoveAllProducts;

public class RemoveAllProductsCommand : IRequest<CartEntity>
{
    public int ProductId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Username { get; set; }
}
