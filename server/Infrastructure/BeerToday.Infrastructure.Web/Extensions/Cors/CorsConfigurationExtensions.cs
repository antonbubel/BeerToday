namespace BeerToday.Infrastructure.Web.Extensions.Cors
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;

    using Infrastructure.Web.Constants;
    using Infrastructure.Web.ConfigurationSections;

    public static class CorsConfigurationExtensions
    {
        public static void ConfigureCors(this IApplicationBuilder app, IConfiguration configuration)
        {
            var corsOptions = configuration.GetSection(ConfigurationSections.CorsSections)
                .Get<CorsConfigurationSection>();

            app.UseCors(options =>
            {
                options.WithOrigins(corsOptions.AllowedOrigins).AllowAnyMethod().AllowAnyHeader();
            });
        }
    }
}
