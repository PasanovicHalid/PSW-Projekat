using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    //ovde menjano
    public class RoomService : IRoomService
    {
        //private readonly IRepository<Room> _roomRepository;
        private readonly IRoomRepository _roomRepository;

        /*
        public RoomService(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }
        */
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public Room GetById(int id)
        {
            return _roomRepository.GetById(id);
        }

        public void Create(Room room)
        {
            _roomRepository.Create(room);
        }

        public void Update(Room room)
        {
            _roomRepository.Update(room);
        }

        public void Delete(Room room)
        {
            _roomRepository.Delete(room);
        }
    }
}
