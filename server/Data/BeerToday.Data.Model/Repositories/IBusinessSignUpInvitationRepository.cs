namespace BeerToday.Data.Model.Repositories
{
    using System.Threading.Tasks;

    using Base;
    using Entities;

    public interface IBusinessSignUpInvitationRepository : IRepository<long, BusinessSignUpInvitation>
    {
        Task<BusinessSignUpInvitation> GetSignUpInvitationByToken(string token);
    }
}
