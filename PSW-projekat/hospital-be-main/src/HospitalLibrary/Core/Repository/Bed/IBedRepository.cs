using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IBedRepository : IRepository<Bed>
    {
        Bed GetByPatientId(int id);
    }
}
