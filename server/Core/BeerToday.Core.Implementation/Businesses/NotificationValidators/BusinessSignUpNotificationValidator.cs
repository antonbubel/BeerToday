namespace BeerToday.Core.Implementation.Businesses.NotificationValidators
{
    using FluentValidation;

    using Constants.ValidationConstants;
    using Contracts.Businesses.Notifications;

    public class BusinessSignUpNotificationValidator : AbstractValidator<BusinessSignUpNotification>
    {
        public BusinessSignUpNotificationValidator()
        {
            RuleFor(notification => notification.Token)
                .NotEmpty();

            RuleFor(notification => notification.Password)
                .NotEmpty()
                .MinimumLength(AuthenticationValidationConstants.PasswordMinLength);

            RuleFor(notification => notification.PasswordConfirmation)
                .Equal(notification => notification.Password);
        }
    }
}
