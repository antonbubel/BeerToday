namespace BeerToday.Data.EF.Repositories
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Model.Entities;
    using Model.Repositories;

    using Base;

    public class BusinessSignUpInvitationRepository : Repository<long, BusinessSignUpInvitation>, IBusinessSignUpInvitationRepository
    {
        public BusinessSignUpInvitationRepository(IDatabaseContext context) : base(context)
        {
        }

        public async Task<BusinessSignUpInvitation> GetSignUpInvitationByToken(string token)
        {
            return await GetQueryable()
                .FirstOrDefaultAsync(invitation => invitation.Token == token);
        }
    }
}
