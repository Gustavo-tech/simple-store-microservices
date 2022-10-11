using Catalog.Domain.Entities;

namespace Catalog.Application.Abstractions;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
}
