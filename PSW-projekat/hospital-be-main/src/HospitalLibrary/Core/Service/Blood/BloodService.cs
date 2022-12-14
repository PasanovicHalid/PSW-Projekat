using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class BloodService : IBloodService
    {
        private readonly IBloodRepository _bloodRepository;

        public BloodService(IBloodRepository bloodRepository)
        {
            _bloodRepository = bloodRepository;

        }
        public void Create(Blood entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blood entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blood> GetAll()
        {
            IEnumerable<Blood> bll = _bloodRepository.GetAll();
            return _bloodRepository.GetAll();
        }

        public Blood GetById(int id)
        {
            return _bloodRepository.GetById(id);
        }

        public void Update(Blood blood)
        {
            blood.Deleted = false;
            _bloodRepository.Update(blood);
        }

        public void updateEmergency(int quantity, BloodType bloodType)
        {
            List<Blood> bloods = (List<Blood>)_bloodRepository.GetAll();
            foreach (Blood blood in bloods) { 
                if(blood.BloodType == bloodType)
                {
                    blood.Quantity += quantity;
                    _bloodRepository.Update(blood);
                    break;
                }
            }
        }

        public void updateQuantityBlood(int bloodId, int quantity, Blood blood)
        {
            Blood blood1 = _bloodRepository.GetById(bloodId);

            int kolicina = blood1.Quantity;
            blood1.Quantity = kolicina - quantity;

            _bloodRepository.Update(blood1);
        }
        public bool StoreBlood(Blood blood)
        {
            List<Blood> bloodTypes = GetByRoom(4);
            foreach(Blood b in bloodTypes)
            {
                if (b.BloodType.Equals(blood.BloodType))
                {
                    b.Quantity += blood.Quantity;
                    _bloodRepository.Update(b);
                    return true;
                }
            }
            return false;
        }

        public List<Blood> GetByRoom(int roomNumber)
        {
            List<Blood> bloodTypes = new List<Blood>();
            foreach(Blood b in GetAll())
            {
                if(b.RoomId == roomNumber)
                    bloodTypes.Add(b);
            }
            return bloodTypes;
        }
    }
}
