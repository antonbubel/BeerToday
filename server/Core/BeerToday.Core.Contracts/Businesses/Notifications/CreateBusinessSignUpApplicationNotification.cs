namespace BeerToday.Core.Contracts.Businesses.Notifications
{
    using MediatR;

    using System.ComponentModel.DataAnnotations;

    using CountryEnum = Data.Model.Enums.Country;

    public class CreateBusinessSignUpApplicationNotification : INotification
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string OrganizationName { get; set; }

        [Required]
        public string OrganizationAddress { get; set; }

        public string Website { get; set; }

        public string Comment { get; set; }

        [Required]
        public CountryEnum Country { get; set; }
    }
}
