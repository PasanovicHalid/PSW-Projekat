using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.BloodConsumption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.BloodConsumption
{
    public class BloodConsumptionService : IBloodConsumptionService
    {

        private readonly IBloodConsumptionRepository _bloodConsumptionRepository;
       

        public BloodConsumptionService(IBloodConsumptionRepository bloodConsumptionRepository)
        {
            _bloodConsumptionRepository = bloodConsumptionRepository;
        }
        public void Create(DoctorBloodConsumption entity)
        {
            _bloodConsumptionRepository.Create(entity);

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
