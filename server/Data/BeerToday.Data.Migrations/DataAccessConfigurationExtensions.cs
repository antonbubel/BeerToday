namespace BeerToday.Data.Migrations
{
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Data.Model;

    public static class DataAccessConfigurationExtensions
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DatabaseContext>(optionsBuilder => ConfigurePostgreSqlDatabase(optionsBuilder, configuration))
                .BuildServiceProvider();

            services.AddScoped<IDatabaseContext, DatabaseContext>();

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
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
