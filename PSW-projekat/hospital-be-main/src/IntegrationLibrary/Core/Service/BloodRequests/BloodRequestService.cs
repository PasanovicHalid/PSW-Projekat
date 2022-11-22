using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.BloodRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.BloodRequests
{
    public class BloodRequestService : IBloodRequestService
    {
        private readonly IBloodRequestRepository _bloodRequestRepository;
        public BloodRequestService(IBloodRequestRepository bloodRequestRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
        }

        public void Create(BloodRequest entity)
        {
            try
            {
                _bloodRequestRepository.Create(entity);
            }
            catch
            {

            }
        }

        public IEnumerable<BloodRequest> GetAcceptedRequests(int id)
        {
            List<BloodRequest> acceptedRequests = new List<BloodRequest>();
            foreach (BloodRequest bloodRequest in _bloodRequestRepository.GetAll())
            {
                if (bloodRequest.BloodBankId == id && bloodRequest.RequestState == RequestState.Accepted)
                    acceptedRequests.Add(bloodRequest);
            }
            return acceptedRequests;
        }

        public BloodRequest GetById(int id)
        {
            return _bloodRequestRepository.GetById(id);
        }
    }
}
