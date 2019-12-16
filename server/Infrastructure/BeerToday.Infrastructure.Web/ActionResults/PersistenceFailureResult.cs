namespace BeerToday.Infrastructure.Web.ActionResults
{
    using Microsoft.AspNetCore.Mvc;

    using System.Net;
    using System.Threading.Tasks;

    using Infrastructure.Exceptions;

    public class PersistenceFailureResult : ObjectResult
    {
        public PersistenceFailureResult(BeerTodayException exception) : base(null)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            await base.ExecuteResultAsync(context);
        }
    }
}
