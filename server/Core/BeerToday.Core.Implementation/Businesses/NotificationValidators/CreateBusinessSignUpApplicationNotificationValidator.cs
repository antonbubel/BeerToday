namespace BeerToday.Core.Implementation.Businesses.NotificationValidators
{
    using FluentValidation;

    using Constants.ValidationConstants;
    using Contracts.Businesses.Notifications;

    public class CreateBusinessSignUpApplicationNotificationValidator : AbstractValidator<CreateBusinessSignUpApplicationNotification>
    {
        public CreateBusinessSignUpApplicationNotificationValidator()
        {
            RuleFor(notification => notification.FirstName)
                .NotEmpty()
                .MaximumLength(UserValidationConstants.DefaultMaxLength);

            RuleFor(notification => notification.LastName)
                .NotEmpty()
                .MaximumLength(UserValidationConstants.DefaultMaxLength);

            RuleFor(notification => notification.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(notification => notification.PhoneNumber)
                .MinimumLength(UserValidationConstants.PhoneNumberMinLength)
                .MaximumLength(UserValidationConstants.PhoneNumberMaxLength)
                .Matches(UserValidationConstants.PhoneNumberFormat)
                .NotEmpty();

            RuleFor(notification => notification.OrganizationName)
                .NotEmpty()
                .MaximumLength(BusinessValidationConstants.OrganizationNameMaxLength);

            RuleFor(notification => notification.OrganizationAddress)
                .NotEmpty()
                .MaximumLength(BusinessValidationConstants.OrganizationAddressMaxLength);

            RuleFor(notification => notification.Website)
                .MaximumLength(UserValidationConstants.DefaultMaxLength);

            RuleFor(notification => notification.Comment)
                .MaximumLength(BusinessValidationConstants.SignUpApplicationCommentMaxLength);
        }
    }
}
