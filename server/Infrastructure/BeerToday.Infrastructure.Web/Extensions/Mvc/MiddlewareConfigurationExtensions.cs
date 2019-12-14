namespace BeerToday.Infrastructure.Web.Extensions.Mvc
{
    using Microsoft.AspNetCore.Mvc;

    using Filters;

    public static class MiddlewareConfigurationExtensions
    {
        public static void UseMiddleware(this MvcOptions opts)
        {
            var responseHandlerFilter = new ResponseFilter();

            opts.Filters.Add(responseHandlerFilter);
        }
    }
}
