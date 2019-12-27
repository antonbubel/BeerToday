namespace BeerToday.Data.EF.ContextMappings
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Identity;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using UserTypeEnum = Model.Enums.UserType;

    public class IdentityRoleClaimMap : IEntityTypeConfiguration<IdentityRoleClaim<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<long>> builder)
        {
            builder.HasData(
                new IdentityRoleClaim<long>
                {
                    Id = 1,
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = UserTypeEnum.User.ToString(),
                    RoleId = (long)UserTypeEnum.User
                },
                new IdentityRoleClaim<long>
                {
                    Id = 2,
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = UserTypeEnum.Business.ToString(),
                    RoleId = (long)UserTypeEnum.Business
                },
                new IdentityRoleClaim<long>
                {
                    Id = 3,
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = UserTypeEnum.Administrator.ToString(),
                    RoleId = (long)UserTypeEnum.Administrator
                }
            );
        }
    }
}
