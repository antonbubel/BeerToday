namespace BeerToday.Web.API.Controllers.Base
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Principal;

    [ApiController]
    [ApiVersion("1.0")]
    public class ApiController : ControllerBase
    {
        public IIdentity LoggedInUser => User.Identity;
    }
}

