namespace BeerToday.Infrastructure.Web.ActionResults
{
    using Microsoft.AspNetCore.Mvc;

    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Infrastructure.Exceptions.Models;

    public class ValidationFailureResult : ObjectResult
    {
        public ValidationFailureResult(IEnumerable<Error> errors) : base(errors)
        {
            StatusCode = (int)HttpStatusCode.UnprocessableEntity;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            await base.ExecuteResultAsync(context);
        }
    }
}
