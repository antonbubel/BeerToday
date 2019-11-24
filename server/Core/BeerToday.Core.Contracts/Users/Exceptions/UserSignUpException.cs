namespace BeerToday.Core.Contracts.Users.Exceptions
{
    using Infrastructure.Exceptions;
    using Infrastructure.Exceptions.Models;

    public class UserSignUpException : BeerTodayException
    {
        public UserSignUpException(Error[] errors) : base(errors)
        {
        }
    }
}
