using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

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
        /// Registers Postgres database-related services and configurations into the dependency injection container.
        /// </summary>
        /// <param name="configuration">The application configuration that holds the necessary Postgres connection and settings.</param>
        public void RegisterPostgres(IConfiguration configuration)
        {
            var pgOptions = configuration.GetRequiredSection(PostgresOptions.Path).Get<PostgresOptions>();
            ArgumentNullException.ThrowIfNull(pgOptions);

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