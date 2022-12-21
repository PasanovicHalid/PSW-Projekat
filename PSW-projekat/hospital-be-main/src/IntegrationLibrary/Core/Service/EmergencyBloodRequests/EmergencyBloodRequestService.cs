using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.BloodBanks;
using IntegrationLibrary.Core.Repository.EmergencyBloodRequests;
using IntegrationLibrary.Protos;

namespace IntegrationLibrary.Core.Service.EmergencyBloodRequests
{
    public class EmergencyBloodRequestService : IEmergencyBloodRequestService
    {
        private readonly IBloodBankRepository _bloodBankRepository;
        private readonly IEmergencyBloodRequestRepository _emergencyBloodRequestRepository;

        public EmergencyBloodRequestService(IBloodBankRepository bloodBankRepository, IEmergencyBloodRequestRepository emergencyBloodRequestRepository)
        {
            _bloodBankRepository = bloodBankRepository;
            _emergencyBloodRequestRepository = emergencyBloodRequestRepository;
        }

        public void RequestEmergencyBlood(EmergencyBloodRequestGRPC request)
        {
            BloodBank bloodBank = _bloodBankRepository.GetById(request.BloodBankID);
            if (bloodBank == null)
            {
                throw new Exception("BloodBank doesnt exist");
            }
            Channel channel = new Channel(bloodBank.GRPCServerAddress, ChannelCredentials.Insecure);
            HttpClient hospitalApiClient = new HttpClient();
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
                    hospitalApiClient = new HttpClient()
                    {
                        BaseAddress = new Uri("http://localhost:16177/")
                    };
                    int temp = ((int)request.BloodType);
                    using HttpResponseMessage response = hospitalApiClient.GetAsync("/api/Blood/emergency/" + ((int)request.BloodType) + "/" + request.BloodQuantity).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();
                    EmergencyBloodRequest emergencyBloodRequest = new EmergencyBloodRequest()
                    {
                        BloodBankId = request.BloodBankID,
                        BloodQuantity = request.BloodQuantity,
                        BloodType = ProtoBloodTypeToBloodType(request.BloodType),
                    };
                    _emergencyBloodRequestRepository.Create(emergencyBloodRequest);

                }
                else
                {
                    throw new Exception("Blood is not available");
                }
                

            } 
            finally
            {
                channel.ShutdownAsync();
                hospitalApiClient.Dispose();
            }
        }
        private BloodType ProtoBloodTypeToBloodType(BloodTypeProto bloodType)
        {
            if (bloodType == BloodTypeProto.Ap)
            {
                return BloodType.AP;
            }
            if (bloodType == BloodTypeProto.An)
            {
                return BloodType.AN;
            }
            if (bloodType == BloodTypeProto.Bp)
            {
                return BloodType.BP;
            }
            if (bloodType == BloodTypeProto.Bn)
            {
                return BloodType.BN;
            }
            if (bloodType == BloodTypeProto.Op)
            {
                return BloodType.OP;
            }
            if (bloodType == BloodTypeProto.On)
            {
                return BloodType.ON;
            }
            if (bloodType == BloodTypeProto.Abp)
            {
                return BloodType.ABP;
            }
                return BloodType.ABN;
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

        public IEnumerable<EmergencyBloodRequest> GetAll()
        {
            return _emergencyBloodRequestRepository.GetAll();
        }
    }
}
