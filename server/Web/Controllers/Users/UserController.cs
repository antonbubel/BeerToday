using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerToday.Web.API.Controllers.Users
{
    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    using Base;

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
        public async Task<IActionResult> SignUp([FromForm]SignUpNotification signUpNotification)
        {
            return Ok();
        }
    }
}

