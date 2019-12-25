namespace BeerToday.Web.API.Controllers.Base
{
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Principal;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ApiVersion("1.0")]
    public class ApiController : ControllerBase
    {
        public IIdentity LoggedInUser => User.Identity;

        public long? LoggedInUserId
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var identifierClaim = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);

                    return long.Parse(identifierClaim.Value);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

