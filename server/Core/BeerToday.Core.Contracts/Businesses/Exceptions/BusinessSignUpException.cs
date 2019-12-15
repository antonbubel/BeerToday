namespace BeerToday.Core.Contracts.Businesses.Exceptions
{
    using Infrastructure.Exceptions;
    using Infrastructure.Exceptions.Models;

    public class BusinessSignUpException : BeerTodayException
    {
        public BusinessSignUpException(Error[] errors) : base(errors)
        {
        }
    }
}
