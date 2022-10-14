using Dapper;
using Npgsql;

namespace Catalog.Infrastructure.Repositories;

public abstract class RepositoryBase
{
    private readonly string _connectionString;

    protected RepositoryBase(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected async Task<IEnumerable<T>> QueryAsync<T>(string query)
    {
        NpgsqlConnection connection = new(_connectionString);
        return await connection.QueryAsync<T>(query);
    }

    protected async Task<T> QueryFirstOrDefaultAsync<T>(string query, object parameters)
    {
        NpgsqlConnection connection = new(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<T>(query, parameters);
    }

    protected async Task ExecuteAsync(string command, object parameters)
    {
        NpgsqlConnection connection = new(_connectionString);
        await connection.ExecuteAsync(command, parameters);
    }
}
