using Microsoft.EntityFrameworkCore.Migrations;

namespace CVA.Infrastructure.Postgres;

/// <summary>
/// Provides dependency injection configuration for the CVA.Infrastructure.Postgres namespace,
/// encapsulating the setup required to register services and dependencies
/// within the assembly.
/// </summary>
public static class DiConfig
{
    extension(IServiceCollection services)
    {
        /// <summary>
        /// Registers PostgreSQL database services and configuration into the provided service collection.
        /// </summary>
        /// <param name="pgOptions">The configuration options for the PostgreSQL database.</param>
        public void RegisterPostgres(PostgresOptions pgOptions)
        {
            services.AddDbContext<PostgresContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseNpgsql(pgOptions.Connection, optionsBuilder =>
                {
                    optionsBuilder.MigrationsAssembly(typeof(PostgresContext).Assembly.FullName);
                    optionsBuilder.MigrationsHistoryTable(HistoryRepository.DefaultTableName);
                });
            });

            services.AddScoped<IUserRepository, UserPostgresRepository>();
            services.AddHostedService<DbMigrationHostedService>();
        }
    }

}