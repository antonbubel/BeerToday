namespace BeerToday.Infrastructure.Web.ConfigurationSections
{
    using System.ComponentModel.DataAnnotations;

    public class JwtConfigurationSection
    {
        [Required]
        public string Authority { get; set; }

        [Required]
        public string Audience { get; set; }

        [Required]
        public string Issuer { get; set; }

        [Required]
        public bool RequireHttpsMetadata { get; set; }
    }
}

