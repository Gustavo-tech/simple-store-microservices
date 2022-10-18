using Cart.Application.Abstractions;
using Cart.Domain.Entities;
using MongoDB.Driver;

namespace Cart.Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly IMongoCollection<CartEntity> _collection;

    public CartRepository(string connectionString)
    {
        MongoClient mc = new(connectionString);
        IMongoDatabase database = mc.GetDatabase("cart");
        _collection = database.GetCollection<CartEntity>("carts");
    }

    public async Task AddCartAsync(CartEntity cart)
    {
        await _collection.InsertOneAsync(cart);
    }

    public async Task<CartEntity> GetCartAsync(string userName) =>
        await _collection.Find(x => x.UserName == userName).FirstOrDefaultAsync();

    public async Task UpdateCartAsync(CartEntity cart)
    {
        FilterDefinition<CartEntity> filter = Builders<CartEntity>.Filter.Eq(s => s.UserName, cart.UserName);
        await _collection.ReplaceOneAsync(filter, cart);
    }
}
