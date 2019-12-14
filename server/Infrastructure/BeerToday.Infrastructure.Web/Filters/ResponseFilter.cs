namespace BeerToday.Infrastructure.Web.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    using FluentValidation;

    using ExceptionHandlers;

    public class ResponseFilter : IActionFilter
    {
        private readonly IValidationExceptionHandler validationExceptionHandler;

        public ResponseFilter(IValidationExceptionHandler validationExceptionHandler)
        {
            this.validationExceptionHandler = validationExceptionHandler;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null && context.Exception is ValidationException)
            {
                context.Result = validationExceptionHandler.Handle(context);

                return;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
