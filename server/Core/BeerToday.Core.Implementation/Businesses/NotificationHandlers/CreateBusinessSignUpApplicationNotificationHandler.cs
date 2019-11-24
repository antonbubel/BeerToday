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

            logger.LogInformation($"About to create a {nameof(BusinessSignUpApplication)}.", application);

            var result = await repository.CreateAsync(application);

            if (result.Status != OperationStatus.Successful)
            {
                logger.LogError($"Creation of {nameof(BusinessSignUpApplication)} failed with not successfull operation result.", result);

                throw new CreateBusinessSignUpApplicationException(result);
            }

            logger.LogInformation($"Creation of {nameof(BusinessSignUpApplication)} succeeded.", result);
        }
    }
}
