using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : RepositoryBase, IProductRepository
{
    public ProductRepository(string connectionString)
        : base(connectionString)
    {
    }

    public async Task<Product> GetByIdAsync(string id)
    {
        string query = "select * from products where id = :Id";
        return await QueryFirstOrDefaultAsync<Product>(query, new { Id = int.Parse(id) });
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        string query = "select * from products";
        return await QueryAsync<Product>(query);
    }

    public async Task AddProductAsync(Product product)
    {
        string command = "insert into products (title, description, quantity, price) values (:Title, :Description, :Quantity, :Price)";
        await ExecuteAsync(command, new { product.Title, product.Description, product.Quantity, product.Price });
    }

    public async Task UpdateProductAsync(Product product)
    {
        string command = @"update products set 
                             title = :Title, 
                             description = :Description, 
                             quantity = :Quantity, 
                             price = :Price
                           where id = :Id";
        await ExecuteAsync(command, new { product.Title, product.Description, product.Quantity, product.Price, product.Id });
    }

    public async Task DeleteProductAsync(int id)
    {
        string command = "delete products where id = :Id";
        await ExecuteAsync(command, new { Id = id });
    } 
}
