namespace BeerToday.Infrastructure.Exceptions
{
    using System;

    using Models;

    public class BeerTodayException : Exception
    {
        public Error[] Errors { get; set; }

        public BeerTodayException(string message) : base(message)
        {
        }

        public BeerTodayException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BeerTodayException(params Error[] errors)
        {
            Errors = errors;
        }
    }
}

