namespace BeerToday.Data.Model.Entities
{
    using Base;
    
    using System.Collections.Generic;

    using BusinessSignUpApplicationStatusEnum = Enums.BusinessSignUpApplicationStatus;

    public class BusinessSignUpApplicationStatus : LookupEntity<BusinessSignUpApplicationStatusEnum>
    {
        public ICollection<BusinessSignUpApplication> BusinessSignUpApplications { get; set; }
    }
}
