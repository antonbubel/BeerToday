namespace BeerToday.Infrastructure.Web.ExceptionHandlers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    using System.Linq;

    using FluentValidation;

    using ActionResults;

    using Exceptions.Models;

    public class ValidationExceptionHandler : IExceptionHandler
    {
        public IActionResult Handle(ActionExecutedContext context)
        {
            var validationException = (ValidationException)context.Exception;
            var errors = validationException.Errors
                .Select(error => new Error(error.ErrorCode, error.ErrorMessage))
                .ToArray();

            return new ValidationFailureResult(errors);
        }
    }
}
