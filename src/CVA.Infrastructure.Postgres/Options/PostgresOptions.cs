namespace CVA.Infrastructure.Postgres;

/// <summary>
/// Configuration options for Postgres database integration.
/// </summary>
internal sealed class PostgresOptions
{
    /// <summary>
    /// Represents the configuration key used to retrieve Postgres options from the configuration system.
    /// </summary>
    public const string Path = "Database:Postgres";

    /// <summary>
    /// Represents the connection string used to establish a connection to the Postgres database.
    /// </summary>
    public required string Connection { get; set; }

    /// <summary>
    /// Represents the duration of a database connection's lifetime in the connection pool, defined in seconds.
    /// </summary>
    public int Lifetime { get; set; }

    /// <summary>
    /// Specifies the minimum size of the connection pool for the Postgres database.
    /// </summary>
    public int MinSize { get; set; }

    /// <summary>
    /// Specifies the maximum size of the connection pool for the Postgres database.
    /// </summary>
    public int MaxSize { get; set; }
}