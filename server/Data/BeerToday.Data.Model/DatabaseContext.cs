namespace BeerToday.Data.Model
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using Entities;

    using Utilities.Common.Extensions;

    public class DatabaseContext : IdentityDbContext<User, Role, long>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var excecutingAssembly = Assembly.GetExecutingAssembly();

            //var entityTypeConfigurations = excecutingAssembly.GetTypes()
            //    .Where(type => type.ImplementGenericInterface(typeof(IEntityTypeConfiguration<>)))
            //    .Select(type => Activator.CreateInstance(type))
            //    .ToList();

            //var applyConfigurationMethod = typeof(ModelBuilder)
            //    .GetMethod(nameof(modelBuilder.ApplyConfiguration));

            //entityTypeConfigurations.ForEach(entityTypeConfiguration =>
            //    applyConfigurationMethod.Invoke(modelBuilder, new object[] { entityTypeConfiguration }));

            base.OnModelCreating(modelBuilder);
        }
    }
}

