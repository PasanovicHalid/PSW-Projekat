using System.Collections.Generic;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IRoomService : IService<Room>
    {
        IEnumerable<BedDto> GetAllBedsByRoom(int roomId);

        public IEnumerable<Medicine> GetAllStorageMedicnes();
        public IEnumerable<Blood> GetAllStorageBloods();
        Blood GetBlood(Blood blood);
        bool ReduceBloodCount(Blood blood);

    }
}
