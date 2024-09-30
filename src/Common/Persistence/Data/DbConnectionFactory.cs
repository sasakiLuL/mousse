using Application.Data;
using Microsoft.Extensions.Options;
using Npgsql;
using Persistence.Options;
using System.Data;

namespace Persistence.Data;

public class DbConnectionFactory(IOptions<ConnectionStringOptions> options) : IDbConnectionFactory, IDisposable
{
    private NpgsqlConnection? _connection;

    public IDbConnection GetOpenConnection()
    {
        if ((_connection ??= new NpgsqlConnection(options.Value.Value)).State != ConnectionState.Open)
        {
            _connection.Open();
        }

        return _connection;
    }

    public void Dispose() => _connection?.Dispose();
}
