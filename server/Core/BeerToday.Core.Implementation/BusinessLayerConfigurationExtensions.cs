namespace BeerToday.Core.Implementation
{
    using AutoMapper;

    using MediatR;

    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;

    public static class BusinessLayerConfigurationExtensions
    {
        public static void ConfigureBusinessLayer(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(executingAssembly);
            services.AddMediatR(executingAssembly);
        }
    }
}
