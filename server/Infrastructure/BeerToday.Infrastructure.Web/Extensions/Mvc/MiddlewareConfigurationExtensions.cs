namespace BeerToday.Infrastructure.Web.Extensions.Mvc
{
    using Microsoft.AspNetCore.Mvc;

    using ExceptionHandlers;

    using Filters;

    public static class MiddlewareConfigurationExtensions
    {
        public static void UseMiddleware(this MvcOptions opts)
        {
            var responseHandlerFilter = new ResponseFilter(
                new ValidationExceptionHandler()
            );

            opts.Filters.Add(responseHandlerFilter);
        }
    }
}
