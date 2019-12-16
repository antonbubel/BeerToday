namespace BeerToday.Data.Model.ContextMappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Entities;

    public class BusinessSignUpApplicationMap : IEntityTypeConfiguration<BusinessSignUpApplication>
    {
        public void Configure(EntityTypeBuilder<BusinessSignUpApplication> builder)
        {
            builder
                .HasOne(application => application.Country)
                .WithMany(country => country.BusinessSignUpApplications)
                .HasForeignKey(application => application.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(application => application.Status)
                .WithMany(applicationStatus => applicationStatus.BusinessSignUpApplications)
                .HasForeignKey(application => application.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
