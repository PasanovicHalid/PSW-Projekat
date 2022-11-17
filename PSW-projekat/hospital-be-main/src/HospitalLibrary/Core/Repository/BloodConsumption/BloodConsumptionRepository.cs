using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.BloodConsumption
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
            throw new NotImplementedException();
        }

        public void Delete(DoctorBloodConsumption entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorBloodConsumption> GetAll()
        {
            throw new NotImplementedException();
        }

        public DoctorBloodConsumption GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DoctorBloodConsumption entity)
        {
            throw new NotImplementedException();
        }
    }
}
