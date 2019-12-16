namespace BeerToday.Data.Model.ContextMappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Entities;
    using UserTypeEnum = Enums.UserType;

    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role {
                    Id = (long)UserTypeEnum.User,
                    Name = UserTypeEnum.User.ToString(),
                    NormalizedName = UserTypeEnum.User.ToString().ToUpperInvariant()
                },
                new Role
                {
                    Id = (long)UserTypeEnum.Business,
                    Name = UserTypeEnum.Business.ToString(),
                    NormalizedName = UserTypeEnum.Business.ToString().ToUpperInvariant()
                },
                new Role
                {
                    Id = (long)UserTypeEnum.Administrator,
                    Name = UserTypeEnum.Administrator.ToString(),
                    NormalizedName = UserTypeEnum.Administrator.ToString().ToUpperInvariant()
                }
            );
        }
    }
}
