namespace BeerToday.Core.Implementation.Businesses.NotificationHandlers
{
    using MediatR;

    using AutoMapper;

    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Security.Claims;
    using System.Collections.Generic;

    using Microsoft.Extensions.Logging;

    using Microsoft.AspNetCore.Identity;

    using Microsoft.EntityFrameworkCore;

    using Contracts.Businesses.Exceptions;
    using Contracts.Businesses.Notifications;

    using Data.Model;
    using Data.Model.Entities;

    using Infrastructure.Exceptions.Models;

    public class BusinessSignUpNotificationHandler : INotificationHandler<BusinessSignUpNotification>
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IRepository<long, BusinessSignUpApplication> applicationsRepository;
        private readonly IRepository<long, BusinessSignUpInvitation> invitationsRepository;
        private readonly ILogger<BusinessSignUpNotificationHandler> logger;

        public BusinessSignUpNotificationHandler(
            IMapper mapper,
            UserManager<User> userManager,
            IRepository<long, BusinessSignUpApplication> applicationsRepository,
            IRepository<long, BusinessSignUpInvitation> invitationsRepository,
            ILogger<BusinessSignUpNotificationHandler> logger)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.applicationsRepository = applicationsRepository;
            this.invitationsRepository = invitationsRepository;
            this.logger = logger;
        }

        public async Task Handle(BusinessSignUpNotification notification, CancellationToken cancellationToken)
        {
            var invitation = await invitationsRepository.GetQueryable()
                .FirstOrDefaultAsync(invitation => invitation.Token == notification.Token);

            if (invitation == null)
            {
                throw new BusinessSignUpInvitationNotFoundException();
            }

            var user = mapper.Map<User>(invitation);

            var createUserResult = await userManager.CreateAsync(user, notification.Password);

            ValidateIdentityResult(createUserResult, user);

            var addToRoleResult = await userManager.AddToRoleAsync(user, user.UserTypeId.ToString());

            ValidateIdentityResult(addToRoleResult, user);

            var addClaimsResult = await AddClaimsToBusinessUser(user);

            ValidateIdentityResult(addClaimsResult, user);

            logger.LogInformation($"Successfully created a user with username: {user.UserName}");
        }

        private async Task<IdentityResult> AddClaimsToBusinessUser(User user)
        {
            return await userManager.AddClaimsAsync(user, new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.UserTypeId.ToString())
            });
        }

        private void ValidateIdentityResult(IdentityResult result, User user)
        {
            if (!result.Succeeded)
            {
                logger.LogError($@"Business user with username {user.UserName} creation failed with identity errors:
                    {string.Join(", ", result.Errors.Select(error => error.Description))}");

                var errors = mapper.Map<Error[]>(result.Errors);
                throw new BusinessSignUpException(errors);
            }
        }
    }
}
