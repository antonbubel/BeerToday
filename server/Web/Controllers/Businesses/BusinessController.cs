namespace BeerToday.Web.API.Controllers.Businesses
{
    using MediatR;

    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Base;

    using Core.Contracts.Businesses.Exceptions;
    using Core.Contracts.Businesses.Notifications;

    using Infrastructure.Web.ActionResults;

    [Route("businesses")]
    public class BusinessController : ApiController
    {
        private readonly IMediator mediator;

        public BusinessController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Create business sign up application
        /// </summary>
        /// <param name="notification">Business sign up application fields</param>
        /// <response code="200">New business sign up application is successfully created</response>
        /// <response code="422">Creation of a business sign up application has failed because of validation errors</response>
        /// <response code="500">Creation of a business sign up application has failed because of database error</response>
        [HttpPost("application")]
        public async Task<IActionResult> CreateSignUpApplication([FromBody]CreateBusinessSignUpApplicationNotification notification)
        {
            try
            {
                await mediator.Publish(notification);
            }
            catch (CreateBusinessSignUpApplicationException exception)
            {
                return new PersistenceFailureResult(exception);
            }

            return Ok();
        }

        /// <summary>
        /// Business sign up
        /// </summary>
        /// <param name="notification">Business sign up fields</param>
        /// <response code="200">New business user is successfully created</response>
        /// <response code="400">Unable to create a business user because the invitation is not found</response>
        /// <response code="422">Creation of a business user has failed because of validation errors</response>
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody]BusinessSignUpNotification notification)
        {
            try
            {
                await mediator.Publish(notification);
            }
            catch (BusinessSignUpInvitationNotFoundException)
            {
                return BadRequest();
            }
            catch (BusinessSignUpException exception)
            {
                return new ValidationFailureResult(exception.Errors);
            }

            return Ok();
        }
    }
}
