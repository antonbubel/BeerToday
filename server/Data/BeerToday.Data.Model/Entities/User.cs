namespace BeerToday.Data.Model.Entities
{
    using Microsoft.AspNetCore.Identity;

    using UserTypeEnum = Enums.UserType;

    public class User : IdentityUser<long>
    {
        public string Nickname { get; set; }

        public string NormalizedNickname { get; set; }

        public UserTypeEnum UserTypeId { get; set; }

        public UserType UserType { get; set; }
    }
}
