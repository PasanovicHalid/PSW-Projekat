using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public interface IBloodService : IService<Blood>
    {
        public void updateQuantityBlood(int bloodId, int quantity, Blood blood);
        public void handleBloodRequest(List<BloodOrderDto> order);

    }
}
