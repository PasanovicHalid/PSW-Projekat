using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;

        }
        public void Create(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _medicineRepository.GetAll();
        }

        public Medicine GetById(int id)
        {
            return _medicineRepository.GetById(id);
        }

        public void Update(Medicine medicine)
        {
            medicine.Deleted = false;
            _medicineRepository.Update(medicine);
        }

        public void updateQuantityMedicine(int medicineId, int quantity, Medicine medicine) { 
       
            Medicine medicine1 = _medicineRepository.GetById(medicineId);

            int kolicina = medicine1.Quantity;
            medicine1.Quantity = kolicina - quantity;

            _medicineRepository.Update(medicine1);
        }
    }
}
