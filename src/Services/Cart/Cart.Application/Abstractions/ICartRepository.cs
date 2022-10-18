using Cart.Domain.Entities;

namespace Cart.Application.Abstractions;

public interface ICartRepository
{
    Task<CartEntity> GetCartAsync(string userName);
    Task AddCartAsync(CartEntity cart);
    Task UpdateCartAsync(CartEntity cart);
}
