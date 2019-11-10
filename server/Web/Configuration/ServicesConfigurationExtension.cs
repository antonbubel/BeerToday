namespace BeerToday.Web.API.Configuration
{
    using AutoMapper;
    using MediatR;

    using System.Linq;
    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServicesConfigurationExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var referencedAssemblies = Assembly.GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Where(assemblyName => assemblyName.FullName.Contains(nameof(BeerToday)))
                .Select(assemblyName => Assembly.Load(assemblyName))
                .ToArray();

            services.AddAutoMapper(referencedAssemblies);
            services.AddMediatR(referencedAssemblies);
        }
    }
}

