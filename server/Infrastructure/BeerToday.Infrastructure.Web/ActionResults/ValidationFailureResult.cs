namespace BeerToday.Infrastructure.Web.ActionResults
{
    using Microsoft.AspNetCore.Mvc;

    using System.Net;
    using System.Threading.Tasks;

    public class ValidationFailureResult : ObjectResult
    {
        public ValidationFailureResult(object value) : base(value)
        {
            StatusCode = (int)HttpStatusCode.UnprocessableEntity;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            await base.ExecuteResultAsync(context);
        }
    }
}
