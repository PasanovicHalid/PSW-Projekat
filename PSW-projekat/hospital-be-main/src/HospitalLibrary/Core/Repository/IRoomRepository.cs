using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IRoomRepository : IRepository<Room>
    {
        ICollection<Blood> GetBloods();
        void ReduceBloodCount(Blood blood, int id);
    }
}
