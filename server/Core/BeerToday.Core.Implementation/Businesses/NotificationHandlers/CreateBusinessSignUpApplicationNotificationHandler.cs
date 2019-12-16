namespace BeerToday.Core.Implementation.Businesses.NotificationHandlers
{
    using MediatR;

    using AutoMapper;

    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using Contracts.Businesses.Exceptions;
    using Contracts.Businesses.Notifications;

    using Data.Model;
    using Data.Model.Results;
    using Data.Model.Entities;

    public class CreateBusinessSignUpApplicationNotificationHandler : INotificationHandler<CreateBusinessSignUpApplicationNotification>
    {
        private readonly IMapper mapper;
        private readonly IRepository<long, BusinessSignUpApplication> repository;
        private readonly ILogger<CreateBusinessSignUpApplicationNotificationHandler> logger;

        public CreateBusinessSignUpApplicationNotificationHandler(
            IMapper mapper,
            IRepository<long, BusinessSignUpApplication> repository,
            ILogger<CreateBusinessSignUpApplicationNotificationHandler> logger)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
        }

        public async Task Handle(CreateBusinessSignUpApplicationNotification notification, CancellationToken cancellationToken)
        {
            var application = mapper.Map<BusinessSignUpApplication>(notification);
            var result = await repository.CreateAsync(application);

            if (result.Status != OperationStatus.Successful)
            {
                logger.LogError($"Creation of a business sign up application failed with not successfull operation result, {result.Exception}");

                throw new CreateBusinessSignUpApplicationException(result);
            }

            logger.LogInformation($@"Successfully created a business sign up application for {notification.FirstName} {notification.LastName},
                Organization name: {notification.OrganizationName}");
        }
    }
}
