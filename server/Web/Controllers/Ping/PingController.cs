namespace BeerToday.Web.API.Controllers.Ping
{
    using MediatR;

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    using Base;

    using Core.Contracts.Ping.Requests;

    [Route("ping")]
    public class PingController : ApiController
    {
        private readonly IMediator mediator;

        public PingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new PingRequest());

            return Ok(response);
        }

    }
}

