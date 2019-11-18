namespace BeerToday.Infrastructure.Web.ConfigurationSections
{
    public class ApiConfigurationSection
    {
        public string BaseUrl { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string[] Clients { get; set; }
    }
}

