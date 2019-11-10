namespace BeerToday.Infrastructure.Exceptions
{
    using System;

    public class BeerTodayException : Exception
    {
        public BeerTodayException()
        {
        }

        public BeerTodayException(string message)
            : base(message)
        {
        }

        public BeerTodayException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

