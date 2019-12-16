namespace BeerToday.Data.Model.ContextMappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Entities;
    using CountryEnum = Enums.Country;

    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(country => country.Id)
                .ValueGeneratedNever();

            builder.Property(country => country.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new Country { Id = CountryEnum.Belarus, Name = CountryEnum.Belarus.ToString() }
            );
        }
    }
}
