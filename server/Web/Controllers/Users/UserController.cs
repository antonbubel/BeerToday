namespace BeerToday.Web.API.Controllers.Users
{
    using MediatR;

    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Base;

    using Core.Contracts.Users.Exceptions;
    using Core.Contracts.Users.Notifications;

    using Infrastructure.Web.ActionResults;

    [Route("users")]
    public class UserController : ApiController
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// User sign up
        /// </summary>
        /// <param name="notification">User sign up fields</param>
        /// <response code="200">New user is successfully created</response>
        /// <response code="422">Creation of a new user has failed because of validation errors</response>
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody]UserSignUpNotification notification)
        {
            try
            {
                await mediator.Publish(notification);
            }
            catch (UserSignUpException exception)
            {
                return new ValidationFailureResult(exception.Errors);
            }

            return Ok();
        }
    }
}
