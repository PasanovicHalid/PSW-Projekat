using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.BloodBanks;
using IntegrationLibrary.Core.Service.EmergencyBloodRequests.ThreadWorkspaces;
using IntegrationLibrary.Protos.EmergencyBloodRequests;

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
            EmergencyRequestThreadWorkspace threadWorkspace = new EmergencyRequestThreadWorkspace(_bloodBankRepository.GetAll(), request);
            threadWorkspace.StartRequestingEmergencyBlood();
        }
    }
}
