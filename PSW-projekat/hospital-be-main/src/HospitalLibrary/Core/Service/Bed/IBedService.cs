using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IBedService : IService<Bed>
    {
        Bed GetByPatientId(int id);
    }
}
