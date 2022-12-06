using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.BloodBanks;
using IntegrationLibrary.Protos;

namespace IntegrationLibrary.Core.Service.EmergencyBloodRequests
{
    public class EmergencyBloodRequestService : IEmergencyBloodRequestService
    {
        private readonly IBloodBankRepository _bloodBankRepository;

        public EmergencyBloodRequestService(IBloodBankRepository bloodBankRepository)
        {
            _bloodBankRepository = bloodBankRepository;
        }

        public void RequestEmergencyBlood(EmergencyBloodRequest request)
        {
            BloodBank bloodBank = _bloodBankRepository.GetById(request.BloodBankID);
            if (bloodBank == null)
            {
                throw new Exception("BloodBank doesnt exist");
            }
            Channel channel = new Channel(bloodBank.GRPCServerAddress, ChannelCredentials.Insecure);
            try
            {

                EmergencyRequestGrpcService.EmergencyRequestGrpcServiceClient client =
                new EmergencyRequestGrpcService.EmergencyRequestGrpcServiceClient(channel);
                CheckRequest checkRequest = new CheckRequest()
                {
                    BloodQuantity = request.BloodQuantity,
                    BloodType = request.BloodType
                };
                DateTime deadline = DateTime.UtcNow.AddSeconds(10);
                CheckResponse checkResponse = client.checkIfBloodIsAvailable(checkRequest);

                if (checkResponse.Availability == BloodAvailability.Available)
                {
                    RequestEmergencyBlood(client, checkRequest);
                }
                else
                {
                    throw new Exception("Blood is not available");
                }
            }
            finally
            {
                channel.ShutdownAsync();
            }
        }

        private void RequestEmergencyBlood(EmergencyRequestGrpcService.EmergencyRequestGrpcServiceClient client, CheckRequest checkRequest)
        {
            DateTime deadline = DateTime.UtcNow.AddSeconds(10);
            EmergencyResponse emergencyResponse = client.requestBlood(
                                new EmergencyRequest()
                                {
                                    Request = checkRequest,
                                }
                                );
            if (emergencyResponse.Status == SendStatus.Denied)
            {
                throw new Exception("Blood request was denied");
            }
        }
    }
}
