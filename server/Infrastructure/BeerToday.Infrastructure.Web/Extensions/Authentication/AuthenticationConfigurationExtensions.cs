namespace BeerToday.Infrastructure.Web.Extensions.Authentication
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;

    using Constants;
    using ConfigurationSections;

    public static class AuthenticationConfigurationExtensions
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var apiOptions = configuration.GetSection(ConfigurationSections.ApiSection)
                .Get<ApiConfigurationSection>();

            var jwtOptions = configuration.GetSection(ConfigurationSections.JwtSection)
                .Get<JwtConfigurationSection>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o =>
            {
                o.Authority = jwtOptions.Authority;
                o.Audience = jwtOptions.Audience;
                o.RequireHttpsMetadata = jwtOptions.RequireHttpsMetadata;
            });

            services.AddAuthorization(options =>
            {
                // TODO: add policies
            });
        }
    }
}
