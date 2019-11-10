using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace BeerToday.Web.API.Configuration
{
    using Data.Model.Entities;

    public static class IdentityServerConfigurationExtensions
    {
        public static void ConfigureIdentityServer(this IServiceCollection services)
        {
            var apiResources = GetApiResources();
            var identityResources = GetIdentityResources();
            var identityServerClients = GetIndentityServerClients();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(apiResources)
                .AddInMemoryIdentityResources(identityResources)
                .AddInMemoryClients(identityServerClients)
                .AddAspNetIdentity<User>();
        }

        private static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("coliseum-api", "BeerToday API", new List<string>
                {
                    ClaimTypes.Name,
                    ClaimTypes.Role
                })
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

        public static IEnumerable<Client> GetIndentityServerClients()
        {
            return new List<Client> 
            {
                new Client
                {
                    ClientId = "coliseum-ui",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AccessTokenLifetime = (int) TimeSpan.FromDays(1).TotalSeconds,
                    AllowedScopes = 
                    {
                        "coliseum-api",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }
    }
}

