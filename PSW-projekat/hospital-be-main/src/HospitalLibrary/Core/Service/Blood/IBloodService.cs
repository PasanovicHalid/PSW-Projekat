using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IBloodService : IService<Blood>
    {
        public void updateQuantityBlood(int bloodId, int quantity, Blood blood);

    }
}
