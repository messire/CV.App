namespace CVA.Infrastructure.Postgres;

/// <inheritdoc />
public sealed class PostgresContext(DbContextOptions<PostgresContext> options)
    : DbContext(options)
{
    /// <summary>
    /// Represents the collection of users in the database context.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}