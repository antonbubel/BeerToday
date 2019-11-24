namespace BeerToday.Core.Contracts.Businesses.Notifications
{
    using System.ComponentModel.DataAnnotations;

    public class BusinessSignUpNotification
    {
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string PasswordConfirmation { get; set; }
    }
}
