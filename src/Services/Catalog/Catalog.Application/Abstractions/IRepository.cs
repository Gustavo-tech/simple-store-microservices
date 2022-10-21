namespace Catalog.Application.Abstractions;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(int id);
}
