namespace BeerToday.Core.Contracts.Businesses.Notifications
{
    using MediatR;

    public class BusinessSignUpNotification : INotification
    {
        public string Token { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }
    }
}
