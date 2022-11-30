using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.CouncilOfDoctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.CouncilOfDoctors
{
    public class CouncilOfDoctorsService : ICouncilOfDoctorsService
    {
        private readonly ICouncilOfDoctorsRepository _councilOfDoctorsRepository;


        public CouncilOfDoctorsService(ICouncilOfDoctorsRepository councilOfDoctorsRepository)
        {
            _councilOfDoctorsRepository = councilOfDoctorsRepository;
        }


        public void Create(DoctorsCouncil entity)
        {
            _councilOfDoctorsRepository.Create(entity);
        }

        public void Delete(DoctorsCouncil entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorsCouncil> GetAll()
        {
            throw new NotImplementedException();
        }

        public DoctorsCouncil GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DoctorsCouncil entity)
        {
            throw new NotImplementedException();
        }
    }
}
