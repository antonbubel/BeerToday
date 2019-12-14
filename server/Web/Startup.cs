namespace BeerToday.Web.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;

    using NLog.Extensions.Logging;

    using Infrastructure.Web.Extensions.Authentication;
    using Infrastructure.Web.Extensions.Cors;
    using Infrastructure.Web.Extensions.IdentityServer;
    using Infrastructure.Web.Extensions.Mvc;
    using Infrastructure.Web.Extensions.Swagger;

    using Core.Implementation;

    using Data.Migrations;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDataAccess(Configuration);

            services.ConfigureBusinessLayer();

            services.AddSwaggerServices();

            services.ConfigureUsers();

            services.ConfigureIdentityServer(Configuration);

            services.ConfigureAuthentication(Configuration);

            services.AddCors();

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(Configuration)
                    .AddConsole()
                    .AddNLog();
            });

            services.AddMvc(options =>
            {
                options.UseMiddleware();
                options.UseGeneralRoutePrefix("api/v{version:apiVersion}");
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider apiVersionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseIdentityServer();

            app.ConfigureSwagger(apiVersionProvider);

            app.ConfigureCors(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

