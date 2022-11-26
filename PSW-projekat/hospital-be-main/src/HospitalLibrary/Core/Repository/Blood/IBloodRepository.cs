using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IBloodRepository : IRepository<Blood>
    {   
        void ReduceBloodCount(Blood blood, int id);
    }
}
