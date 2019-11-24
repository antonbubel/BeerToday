namespace BeerToday.Data.Model.Entities
{
    using System.Collections.Generic;

    using Base;

    using CountryEnum = Enums.Country;

    public class Country : LookupEntity<CountryEnum>
    {
        public virtual ICollection<BusinessSignUpApplication> BusinessSignUpApplications { get; set; }
    }
}
