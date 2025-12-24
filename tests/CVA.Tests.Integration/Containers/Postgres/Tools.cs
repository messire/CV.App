using CVA.Infrastructure.Postgres;

namespace CVA.Tests.Integration.Postgres;

internal static class Tools
{
    public static (PostgresOptions Options, Dictionary<string, string> Config) GetConfiguration(string connectionString)
    {
        var options = GetPostgresOptions(connectionString);
        var config = GetDatabaseConfiguration(options);
        return (options, config);
    }

    private static PostgresOptions GetPostgresOptions(string connectionString)
        => new()
        {
            Connection = connectionString,
            Lifetime = 300,
            MaxSize = 10,
            MinSize = 1,
        };

    public static Dictionary<string, string> GetDatabaseConfiguration(PostgresOptions options)
        => new()
        {
            { "Postgres:Connections:Primary", options.Connection },
            { "Postgres:Pooling:Lifetime", options.Lifetime.ToString() },
            { "Postgres:Pooling:MaxSize", options.MaxSize.ToString() },
            { "Postgres:Pooling:MinSize", options.MinSize.ToString() },
        };
}