using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BeerToday.Data.Migrations
{
    using Data.Model;
    using System.Reflection;

    public static class DataAccessConfigurationExtension
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DatabaseContext>(optionsBuilder => ConfigurePostgreSqlDatabase(optionsBuilder, configuration))
                .BuildServiceProvider();
        }

        private static void ConfigurePostgreSqlDatabase(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(nameof(DatabaseContext));
            var assemblyName = Assembly.GetExecutingAssembly()
                .GetName();

            optionsBuilder.UseNpgsql(
                connectionString,
                serverOptions => serverOptions.MigrationsAssembly(assemblyName.Name)
            );
        }
    }
}

