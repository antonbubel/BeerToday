namespace BeerToday.Data.EF.Migrations
{
    using System.Linq;
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Data.Model.Repositories.Base;

    using Data.EF;
    using Data.EF.Repositories.Base;

    using Utilities.Common.Extensions;

    public static class DataAccessConfigurationExtensions
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterDatabaseContext(services, configuration);
            RegisterRepositories(services);
        }

        private static void RegisterDatabaseContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DatabaseContext>(optionsBuilder => ConfigurePostgreSqlDatabase(optionsBuilder, configuration))
                .BuildServiceProvider();

            services.AddScoped<IDatabaseContext, DatabaseContext>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            var repositoryAbstractionsAssembly = typeof(IRepository<,>).Assembly;
            var repositoryImplementationsAssembly = typeof(Repository<,>).Assembly;

            var repositoryTypes = repositoryAbstractionsAssembly.GetTypes()
                .Where(type => type.ImplementGenericInterface(typeof(IRepository<,>)))
                .ToArray();

            var repositoryImplementationsAssemblyTypes = repositoryImplementationsAssembly.GetTypes();

            foreach (var repositoryType in repositoryTypes)
            {
                var repositoryImplementationType = repositoryImplementationsAssemblyTypes
                    .FirstOrDefault(type => repositoryType.IsAssignableFrom(type));

                services.AddScoped(repositoryType, repositoryImplementationType);
            }
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
