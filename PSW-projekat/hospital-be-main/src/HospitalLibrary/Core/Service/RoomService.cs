using System.Collections.Generic;
using System.Collections.ObjectModel;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Repository;

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

        public IEnumerable<BedDto> GetAllBedsByRoom(int roomId)
        {
            foreach (Room room in _roomRepository.GetAll())
            {
                if (room.Id == roomId)
                {
                    if (CreateBedDto(room.Beds) != null)
                    {
                        return CreateBedDto(room.Beds);
                    }
                }
            }

            return null;
        }


        public ICollection<BedDto> CreateBedDto(ICollection<Bed> pomocniKreveti)
        {
            List<BedDto> bedDtos = new List<BedDto>();
            ICollection<BedDto> beds = new Collection<BedDto>();

            foreach (Bed pomocniKrevet in pomocniKreveti)
            {
                if (pomocniKrevet.BedState == Model.Enums.BedState.taken) { continue; }

                BedDto bedDto = new BedDto();
                bedDto.Id = pomocniKrevet.Id;
                bedDto.Name = pomocniKrevet.Name;
                bedDto.Quantity = pomocniKrevet.Quantity;
                bedDto.BedState = pomocniKrevet.BedState;

                bedDtos.Add(bedDto);
                beds.Add(bedDto);
            }

            return beds;
        }

        public IEnumerable<Medicine> GetAllStorageMedicnes()
        {
            ICollection<Medicine> medicines = new Collection<Medicine>();

            foreach (Room room in _roomRepository.GetAll())
            {
                if (!(room.RoomType.Equals(RoomType.storage))) continue;

                foreach (Medicine medicine in room.Medicines) 
                {
                    if (medicine.Quantity == 0) continue;
                    medicines.Add(medicine);
                }
                return medicines;
              
            }
            return null;
        }

        public IEnumerable<Blood> GetAllStorageBloods()
        {
            ICollection<Blood> bloods = new Collection<Blood>();

            foreach (Room room in _roomRepository.GetAll())
            {
                if (!(room.RoomType.Equals(RoomType.storage))) continue;

                foreach (Blood blood in room.Bloods)
                {
                    if (blood.Quantity == 0) continue;
                    bloods.Add(blood);
                }
                return bloods;

            }
            return null;
        }


    }
}
