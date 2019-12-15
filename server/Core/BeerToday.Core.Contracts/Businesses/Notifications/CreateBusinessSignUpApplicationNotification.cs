namespace BeerToday.Core.Contracts.Businesses.Notifications
{
    using MediatR;

    using CountryEnum = Data.Model.Enums.Country;

    public class CreateBusinessSignUpApplicationNotification : INotification
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string OrganizationName { get; set; }

        public string OrganizationAddress { get; set; }

        public string Website { get; set; }

        public string Comment { get; set; }

        public CountryEnum Country { get; set; }
    }
}
