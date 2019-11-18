namespace BeerToday.Infrastructure.Web.Extensions.IdentityServer
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    using IdentityServer4;
    using IdentityServer4.Models;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Constants;
    using ConfigurationSections;

    using Data.Model.Entities;

    public static class IdentityServerConfigurationExtensions
    {
        public static void ConfigureIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            var apiOptions = configuration.GetSection(ConfigurationSections.ApiSection)
                .Get<ApiConfigurationSection>();

            var apiResources = GetApiResources(apiOptions);
            var identityResources = GetIdentityResources();
            var identityServerClients = GetIndentityServerClients(apiOptions);

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(apiResources)
                .AddInMemoryIdentityResources(identityResources)
                .AddInMemoryClients(identityServerClients)
                .AddAspNetIdentity<User>();
        }

        private static IEnumerable<ApiResource> GetApiResources(ApiConfigurationSection apiConfiguration)
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = apiConfiguration.Name,
                    DisplayName = apiConfiguration.DisplayName,
                    UserClaims = new List<string>
                    {
                        ClaimTypes.Name,
                        ClaimTypes.Role
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetIndentityServerClients(ApiConfigurationSection apiConfiguration)
        {
            return apiConfiguration.Clients
                .Select(clientId => new Client
                {
                    ClientId = clientId,
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AccessTokenLifetime = (int)TimeSpan.FromDays(1).TotalSeconds,
                    AllowedScopes =
                    {
                        apiConfiguration.Name,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                })
                .ToList();
        }
    }
}
