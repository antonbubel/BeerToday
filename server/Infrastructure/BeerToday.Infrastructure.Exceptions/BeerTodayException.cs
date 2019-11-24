namespace BeerToday.Infrastructure.Exceptions
{
    using System;

    using Models;

    public class BeerTodayException : Exception
    {
        public Error[] Errors { get; set; }

        public BeerTodayException(params Error[] errors)
        {
            Errors = errors;
        }
    }
}

