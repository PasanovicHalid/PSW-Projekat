using System.Collections.Generic;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IRoomRepository : IRepository<Room>
    {
        ICollection<Blood> GetBloods();
        void ReduceBloodCount(Blood blood, int id);
    }
}
