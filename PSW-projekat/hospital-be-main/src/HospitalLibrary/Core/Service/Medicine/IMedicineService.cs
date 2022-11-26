using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IMedicineService : IService<Medicine>
    {
        public void updateQuantityMedicine(int medicineId, int quantity, Medicine medicine);

    }
}
