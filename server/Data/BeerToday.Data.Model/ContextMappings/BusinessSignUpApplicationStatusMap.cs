namespace BeerToday.Data.Model.ContextMappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Entities;
    using BusinessSignUpApplicationStatusEnum = Enums.BusinessSignUpApplicationStatus;

    public class BusinessSignUpApplicationStatusMap : IEntityTypeConfiguration<BusinessSignUpApplicationStatus>
    {
        public void Configure(EntityTypeBuilder<BusinessSignUpApplicationStatus> builder)
        {
            builder.Property(country => country.Id)
                .ValueGeneratedNever();

            builder.Property(country => country.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new BusinessSignUpApplicationStatus
                { 
                    Id = BusinessSignUpApplicationStatusEnum.Undefined,
                    Name = BusinessSignUpApplicationStatusEnum.Undefined.ToString()
                },
                new BusinessSignUpApplicationStatus
                {
                    Id = BusinessSignUpApplicationStatusEnum.Active,
                    Name = BusinessSignUpApplicationStatusEnum.Active.ToString()
                },
                new BusinessSignUpApplicationStatus
                {
                    Id = BusinessSignUpApplicationStatusEnum.Withdrawn,
                    Name = BusinessSignUpApplicationStatusEnum.Withdrawn.ToString()
                },
                new BusinessSignUpApplicationStatus
                {
                    Id = BusinessSignUpApplicationStatusEnum.Approved,
                    Name = BusinessSignUpApplicationStatusEnum.Approved.ToString()
                },
                new BusinessSignUpApplicationStatus
                {
                    Id = BusinessSignUpApplicationStatusEnum.Rejected,
                    Name = BusinessSignUpApplicationStatusEnum.Rejected.ToString()
                }
            );
        }
    }
}
