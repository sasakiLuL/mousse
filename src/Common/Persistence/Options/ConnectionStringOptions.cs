namespace Persistence.Options;

public class ConnectionStringOptions
{
    public string Value { get; internal set; } = string.Empty;

    public static implicit operator string(ConnectionStringOptions connectionString) => connectionString.Value;

    public static readonly string Section = "Database";
}
