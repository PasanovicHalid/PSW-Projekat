using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.BloodRequests;
using IntegrationLibrary.Core.Service.BloodRequests;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationAPITests.Tests
{
    public class BloodBankReportPDFTests
    {
        [Fact]
        public void Find_accepted_requests_for_bank()
        {
            BloodRequestService service = new BloodRequestService(CreateStubRepository());

            List<BloodRequest> requests = service.getAcceptedRequests(7);
            requests.ShouldBeSameAs(CreateRequestList());
        }
        private static IBloodRequestRepository CreateStubRepository() {
            var stubRepository = new Mock<IBloodRequestRepository>();
            var requests = new List<BloodRequest>();

            BloodRequest req1 = new BloodRequest(new DateTime(2022, 12, 1), 2, "for operation", 1, RequestState.Accepted, BloodType.BP, 7);
            BloodRequest req2 = new BloodRequest(new DateTime(2022, 12, 3), 3, "for operation", 1, RequestState.Accepted, BloodType.BN, 7);
            BloodRequest req3 = new BloodRequest(new DateTime(2022, 12, 12), 1, "for operation", 1, RequestState.Accepted, BloodType.AP, 8);
            BloodRequest req4 = new BloodRequest(new DateTime(2022, 12, 22), 4, "for operation", 1, RequestState.Pending, BloodType.ABN, 8);

            requests.Add(req1);
            requests.Add(req2);
            requests.Add(req3);
            requests.Add(req4);

            stubRepository.Setup(x => x.GetAll()).Returns(requests);
            return stubRepository.Object;
        }
        private static List<BloodRequest> CreateRequestList(){
            var requestList = new List<BloodRequest>();
            BloodRequest req1 = new BloodRequest(new DateTime(2022, 12, 1), 2, "for operation", 1, RequestState.Accepted, BloodType.BP, 7);
            BloodRequest req2 = new BloodRequest(new DateTime(2022, 12, 3), 3, "for operation", 1, RequestState.Accepted, BloodType.BN, 7);
            requestList.Add(req1);
            requestList.Add(req2);
            return requestList;
        }
        
    }
}
