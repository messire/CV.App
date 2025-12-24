using CVA.Infrastructure.Postgres;
using CVA.Tests.Integration.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace CVA.Tests.Integration.Tests.Infrastructure.Postgres;

/// <summary>
/// Base class for repository tests.
/// </summary>
[Collection(nameof(PostgresCollection))]
public abstract class PostgresTestBase : IAsyncLifetime
{
    /// <summary>
    /// Represents a container or setup context for test data or test dependencies.
    /// </summary>
    protected readonly PostgresFixture Fixture;

    /// <summary>
    /// Encapsulates configuration options and settings required to connect to a PostgreSQL database.
    /// </summary>
    protected readonly PostgresOptions PostgresOptions;

    /// <summary>
    /// Represents a cancellation token source used to propagate notifications that operations should be canceled.
    /// </summary>
    protected readonly CancellationTokenSource Cts;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostgresTestBase"/> class.
    /// </summary>
    /// <param name="fixture">The fixture used for test setup and data management.</param>
    protected PostgresTestBase(PostgresFixture fixture)
    {
        Fixture = fixture;
        (PostgresOptions, _) = Integration.Postgres.Tools.GetConfiguration(Fixture.ConnectionString);
        Cts = new CancellationTokenSource();
    }

    /// <summary>
    /// Creates and initializes a new context for the application, which is used to manage
    /// configuration, services, or other resources required for execution.
    /// </summary>
    /// <returns>An object representing the newly created context.</returns>
    protected PostgresContext CreateContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<PostgresContext>();
        optionsBuilder.UseNpgsql(PostgresOptions.Connection);
        return new PostgresContext(optionsBuilder.Options);
    }

    /// <summary>
    /// Asynchronously initializes the necessary components or services required for the application's operation.
    /// </summary>
    /// <returns>A task that represents the completion of the initialization process.</returns>
    public virtual async Task InitializeAsync()
    {
        await using var context = CreateContext();
        await context.Database.MigrateAsync();
        await context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE \"users\" RESTART IDENTITY CASCADE;");
    }

    /// <summary>
    /// Asynchronously releases all resources used by the current instance of the class,
    /// ensuring proper cleanup and freeing of unmanaged resources.
    /// </summary>
    /// <returns>A task that represents the asynchronous dispose operation.</returns>
    public async Task DisposeAsync()
    {
        await Cts.CancelAsync();
    }
}