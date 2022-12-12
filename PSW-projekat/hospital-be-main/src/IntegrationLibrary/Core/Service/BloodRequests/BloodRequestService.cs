using IntegrationLibrary.Core.BloodBankConnection;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.BloodRequests;
using IntegrationLibrary.Core.Service.BloodBanks;
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
        private readonly IBloodBankService _bloodBankService;
        public BloodRequestService(IBloodRequestRepository bloodRequestRepository, IBloodBankService bloodBankService)
        {
            _bloodRequestRepository = bloodRequestRepository;
            _bloodBankService = bloodBankService;
        }

        public void AcceptRequest(BloodRequest request)
        {
            Update(request);
            if(request.RequiredForDate.Date <= DateTime.Now.Date)
            {
                SendRequest(request);
            }

        }

        public void Create(BloodRequest entity)
        {
            try
            {
                _bloodRequestRepository.Create(entity);
            }
            catch
            {
                throw new Exception("Error when creating a blood Request");
            }
        }

        public void DeclineRequest(int id)
        {
            BloodRequest request = _bloodRequestRepository.GetById(id);
            request.RequestState = RequestState.Declined;
            _bloodRequestRepository.Update(request);
        }

        public void Delete(BloodRequest entity)
        {
            _bloodRequestRepository.Delete(entity);
        }

        public IEnumerable<BloodRequest> GetAll()
        {
            return _bloodRequestRepository.GetAll();
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

        public void SendBackRequest(int id, string reason)
        {
            BloodRequest request = _bloodRequestRepository.GetById(id);
            request.RequestState = RequestState.Returned;
            request.Comment = reason;
            _bloodRequestRepository.Update(request);
        }

        public void Update(BloodRequest entity)
        {
            _bloodRequestRepository.Update(entity);
        }
        public List<BloodRequest> GetReturnedRequestsForDoctor(int id)
        {
            List<BloodRequest> returnedRequests = new List<BloodRequest>();
            foreach(BloodRequest b in _bloodRequestRepository.GetAll())
            {
                if(b.DoctorId.Equals(id) && b.RequestState.Equals(RequestState.Returned))
                    returnedRequests.Add(b);
            }
            return returnedRequests;
        }

        public void UpdateFromDoctor(BloodRequest request)
        {
            request.RequestState = RequestState.Pending;
            _bloodRequestRepository.Update(request);
        }

        private void SendRequest(BloodRequest request)
        {
            _bloodBankService.GetBlood(_bloodBankService.GetById(request.BloodBankId), request.BloodType, request.BloodQuantity);
        }
    }
}
