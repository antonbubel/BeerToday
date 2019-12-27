namespace BeerToday.Data.EF.Repositories
{
    using Model.Entities;
    using Model.Repositories;

    using Base;

    public class BusinessSignUpApplicationRepository : Repository<long, BusinessSignUpApplication>, IBusinessSignUpApplicationRepository
    {
        public BusinessSignUpApplicationRepository(IDatabaseContext context) : base(context)
        {
        }
    }
}
