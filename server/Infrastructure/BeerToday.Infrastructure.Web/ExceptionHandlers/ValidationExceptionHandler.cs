namespace BeerToday.Infrastructure.Web.ExceptionHandlers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    using FluentValidation;

    using ActionResults;

    public class ValidationExceptionHandler : IValidationExceptionHandler
    {
        public IActionResult Handle(ActionExecutedContext context)
        {
            var validationException = (ValidationException)context.Exception;
            var modelState = context.ModelState;

            foreach (var error in validationException.Errors)
            {
                modelState.AddModelError(error.ErrorCode ?? string.Empty, error.ErrorMessage);
            }

            return new ValidationFailureResult(context.Result);
        }
    }
}
