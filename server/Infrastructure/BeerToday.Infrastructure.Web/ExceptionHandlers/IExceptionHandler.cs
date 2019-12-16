namespace BeerToday.Infrastructure.Web.ExceptionHandlers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public interface IExceptionHandler
    {
        IActionResult Handle(ActionExecutedContext context);
    }
}
