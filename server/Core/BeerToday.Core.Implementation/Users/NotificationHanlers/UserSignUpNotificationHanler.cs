namespace BeerToday.Core.Implementation.Users.NotificationHanlers
{
    using MediatR;

    using AutoMapper;

    using Microsoft.AspNetCore.Identity;

    using Microsoft.Extensions.Logging;

    using System.Threading;
    using System.Threading.Tasks;
    using System.Security.Claims;
    using System.Collections.Generic;

    using Data.Model.Entities;

    using Contracts.Users.Exceptions;
    using Contracts.Users.Notifications;

    using Infrastructure.Exceptions.Models;

    public class UserSignUpNotificationHanler : INotificationHandler<UserSignUpNotification>
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly ILogger<UserSignUpNotificationHanler> logger;

        public UserSignUpNotificationHanler(
            IMapper mapper,
            UserManager<User> userManager,
            ILogger<UserSignUpNotificationHanler> logger)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task Handle(UserSignUpNotification notification, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(notification);

            logger.LogInformation($"About to create a new {nameof(User)}.", user);

            var createUserResult = await userManager.CreateAsync(user, notification.Password);
            
            ValidateIdentityResult(createUserResult);
            
            logger.LogInformation($"Creation of {nameof(User)} is succeeded.", createUserResult);

            var addToRoleResult = await userManager.AddToRoleAsync(user, user.UserTypeId.ToString());
            
            ValidateIdentityResult(addToRoleResult);
            
            logger.LogInformation($"{nameof(User)} is successfully added to a role {user.UserTypeId.ToString()}.", addToRoleResult);

            var addClaimsResult = await AddClaimsToUser(user);
            
            ValidateIdentityResult(addClaimsResult);
            
            logger.LogInformation($"Claims were successfully added to the {nameof(User)}.", addClaimsResult);
        }

        private async Task<IdentityResult> AddClaimsToUser(User user)
        {
            return await userManager.AddClaimsAsync(user, new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName)
            });
        }

        private void ValidateIdentityResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                logger.LogError($"User creation failed.", result);

                var errors = mapper.Map<Error[]>(result.Errors);
                throw new UserSignUpException(errors);
            }
        }
    }
}
