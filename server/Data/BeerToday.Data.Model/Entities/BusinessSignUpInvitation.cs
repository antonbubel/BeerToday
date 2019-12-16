namespace BeerToday.Data.Model.Entities
{
    using Base;

    public class BusinessSignUpInvitation : BaseEntity<long>
    {
        public BusinessSignUpApplication BusinessSignUpApplication { get; set; }

        public string Token { get; set; }
    }
}
