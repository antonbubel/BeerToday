namespace BeerToday.Core.Implementation.Users.NotificationHanlers
{
    using MediatR;
    using AutoMapper;

    using System.Threading;
    using System.Threading.Tasks;

    using Data.Model.Entities;
    using Contracts.Users.Notifications;
    using Microsoft.AspNetCore.Identity;

    public class SignUpNotificationHanler : INotificationHandler<SignUpNotification>
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public SignUpNotificationHanler(IMapper mapper, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public Task Handle(SignUpNotification notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
