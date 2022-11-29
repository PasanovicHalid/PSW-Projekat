using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using IntegrationAPI.Protos;
using IntegrationAPI.Protos.EmergencyBloodRequests;

namespace IntegrationAPI.sRPC_Services
{
    public class EmergencyRequestService : IHostedService
    {
        private EmergencyRequestService.EmergencyRequestServiceClient client;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
