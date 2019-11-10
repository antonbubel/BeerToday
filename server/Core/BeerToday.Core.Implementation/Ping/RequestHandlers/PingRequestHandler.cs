namespace BeerToday.Core.Implementation.Ping.RequestHandlers
{
    using MediatR;

    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Ping.Requests;

    public class PingRequestHandler : IRequestHandler<PingRequest, string>
    {
        public async Task<string> Handle(PingRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult("Pong");
        }
    }
}

