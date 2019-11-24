namespace BeerToday.Data.Model.Entities
{
    using Base;

    using CountryEnum = Enums.Country;
    using BusinessSignUpApplicationStatusEnum = Enums.BusinessSignUpApplicationStatus;

    public class BusinessSignUpApplication : BaseEntity<long>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string OrganizationName { get; set; }

        public string OrganizationAddress { get; set; }

        public string Website { get; set; }

        public string Comment { get; set; }

        public CountryEnum CountryId { get; set; }

        public Country Country { get; set; }

        public BusinessSignUpApplicationStatusEnum StatusId { get; set; }

        public BusinessSignUpApplicationStatus Status { get; set; }
    }
}
