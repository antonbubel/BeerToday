namespace BeerToday.Data.Model.ContextMappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Entities;

    public class BusinessSignUpInvitationMap : IEntityTypeConfiguration<BusinessSignUpInvitation>
    {
        public void Configure(EntityTypeBuilder<BusinessSignUpInvitation> builder)
        {
            builder.Property(invitation => invitation.Id)
                .ValueGeneratedNever();

            builder
                .HasOne(invitation => invitation.BusinessSignUpApplication)
                .WithOne(application => application.BusinessSignUpInvitation)
                .HasForeignKey<BusinessSignUpInvitation>(invitation => invitation.Id);
        }
    }
}
