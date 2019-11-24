namespace BeerToday.Web.API.Controllers.Users
{
    using MediatR;

    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Base;

    using Core.Contracts.Users.Exceptions;
    using Core.Contracts.Users.Notifications;

    [Route("users")]
    public class UserController : ApiController
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody]UserSignUpNotification notification)
        {
            try
            {
                await mediator.Publish(notification);
            }
            catch (UserSignUpException exception)
            {
                return BadRequest(exception.Errors);
            }

            return Ok();
        }
    }
}
