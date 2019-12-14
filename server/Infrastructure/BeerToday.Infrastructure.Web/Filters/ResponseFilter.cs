namespace BeerToday.Infrastructure.Web.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    using System;
    using System.Collections.Generic;

    using FluentValidation;

    using ExceptionHandlers;

    public class ResponseFilter : IActionFilter
    {
        private readonly IReadOnlyDictionary<Type, IExceptionHandler> ExceptionHandlers = new Dictionary<Type, IExceptionHandler>
        {
            { typeof(ValidationException), new ValidationExceptionHandler() }
        };

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null && ExceptionHandlers.ContainsKey(context.Exception.GetType()))
            {
                var exceptionHandler = ExceptionHandlers[context.Exception.GetType()];

                context.Result = exceptionHandler.Handle(context);
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
