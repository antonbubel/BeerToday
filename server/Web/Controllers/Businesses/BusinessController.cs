namespace BeerToday.Web.API.Controllers.Businesses
{
    using MediatR;

    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Base;

    using Core.Contracts.Businesses.Exceptions;
    using Core.Contracts.Businesses.Notifications;

    [Route("businesses")]
    public class BusinessController : ApiController
    {
        private readonly IMediator mediator;

        public BusinessController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("application")]
        public async Task<IActionResult> SignUp([FromBody]CreateBusinessSignUpApplicationNotification notification)
        {
            try
            {
                await mediator.Publish(notification);
            }
            catch (CreateBusinessSignUpApplicationException exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
