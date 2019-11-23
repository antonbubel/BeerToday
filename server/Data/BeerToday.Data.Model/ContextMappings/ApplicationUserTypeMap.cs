namespace BeerToday.Data.Model.ContextMappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Entities;

    public class ApplicationUserTypeMap : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.Property(userType => userType.Id)
                .ValueGeneratedNever();

            builder.Property(userType => userType.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
