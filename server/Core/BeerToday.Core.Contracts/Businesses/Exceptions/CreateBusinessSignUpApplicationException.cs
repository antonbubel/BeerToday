namespace BeerToday.Core.Contracts.Businesses.Exceptions
{
    using Infrastructure.Exceptions;

    using Data.Model.Results;
    using Data.Model.Entities;

    public class CreateBusinessSignUpApplicationException : BeerTodayException
    {
        public CreateBusinessSignUpApplicationException(OperationResult<BusinessSignUpApplication> operationResult)
            : base(operationResult.Message, operationResult.Exception)
        {
        }
    }
}
