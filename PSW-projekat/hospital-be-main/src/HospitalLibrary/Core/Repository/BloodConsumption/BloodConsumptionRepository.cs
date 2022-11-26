using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Repository
{
    public class BloodConsumptionRepository : IBloodConsumptionRepository
    {
        private readonly HospitalDbContext _context;

        public BloodConsumptionRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(DoctorBloodConsumption entity)
        {
            _context.BloodConsumptions.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(DoctorBloodConsumption entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorBloodConsumption> GetAll()
        {
            return _context.BloodConsumptions.ToList();
        }

        public DoctorBloodConsumption GetById(int id)
        {
            return _context.BloodConsumptions.Find(id);
        }

        public void Update(DoctorBloodConsumption entity)
        {
            throw new NotImplementedException();
        }
    }
}
