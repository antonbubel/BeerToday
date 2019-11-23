namespace BeerToday.Data.Model.ContextMappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Entities;

    public class ApplicationUserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(user => user.UserType)
                .WithMany(userType => userType.Users)
                .HasForeignKey(user => user.UserTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
