namespace BeerToday.Infrastructure.Web.Extensions.IdentityServer
{
    using Microsoft.AspNetCore.Identity;

    using Microsoft.Extensions.DependencyInjection;

    using Data.Model;
    using Data.Model.Entities;

    public static class IdentityUserConfigurationExtensions
    {
        public static void ConfigureUsers(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();
        }
    }
}
