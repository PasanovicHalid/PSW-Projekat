using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.BloodRequests
{
    public interface IBloodRequestService : ICRUDService<BloodRequest>
    {
        void AcceptRequest(int id);
        void DeclineRequest(int id);
        void SendBackRequest(int id, string reason);
        List<BloodRequest> GetReturnedRequestsForDoctor(int id);
        void UpdateFromDoctor(BloodRequest request);
    }
}
