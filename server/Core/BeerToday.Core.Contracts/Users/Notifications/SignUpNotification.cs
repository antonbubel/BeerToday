namespace BeerToday.Core.Contracts.Users.Notifications
{
    using System.ComponentModel.DataAnnotations;

    public class SignUpNotification
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string PasswordConfirmation { get; set; }
    }
}

