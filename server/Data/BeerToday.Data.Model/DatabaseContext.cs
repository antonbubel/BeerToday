namespace BeerToday.Data.Model
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using Entities;

    using Results;

    using Utilities.Common.Extensions;

    public class DatabaseContext : IdentityDbContext<User, Role, long>, IDatabaseContext
    {
        public DbSet<UserType> UserTypes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public new EntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry(entity);
        }

        public CommitResult Commit()
        {
            try
            {
                SaveChanges();
                return new CommitResult(true);
            }
            catch (Exception ex)
            {
                return new CommitResult(ex);
            }
        }

        public async Task<CommitResult> CommitAsync()
        {
            try
            {
                await SaveChangesAsync();

                return new CommitResult(true);
            }
            catch (Exception exception)
            {
                return new CommitResult(exception);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var excecutingAssembly = Assembly.GetExecutingAssembly();

            var contextMappingTypes = excecutingAssembly
                .GetTypes()
                .Where(type => type.ImplementGenericInterface(typeof(IEntityTypeConfiguration<>)))
                .ToArray();

            var applyConfigurationMethod = typeof(ModelBuilder)
                .GetMethods()
                .Where(method => method.Name == nameof(modelBuilder.ApplyConfiguration))
                .First(method => method.GetParameters().Any(parameter => parameter.ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach(var contextMappingType in contextMappingTypes)
            {
                var entityType = contextMappingType.GetGenericInterfaceArguments(typeof(IEntityTypeConfiguration<>))
                    .First();

                var contextMap = Activator.CreateInstance(contextMappingType);

                applyConfigurationMethod.MakeGenericMethod(entityType)
                    .Invoke(modelBuilder, new[] { contextMap });
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}

