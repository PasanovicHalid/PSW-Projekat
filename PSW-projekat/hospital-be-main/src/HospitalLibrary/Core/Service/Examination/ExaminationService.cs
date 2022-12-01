using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationRepository _examinationRepository;

        public ExaminationService(IExaminationRepository examinationRepository)
        {
            _examinationRepository = examinationRepository;
        }

        public void Create(Examination entity)
        {
            entity.Deleted = false;
            _examinationRepository.Create(entity);
        }

        public void Delete(Examination entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Examination> GetAll()
        {
            return _examinationRepository.GetAll();
        }

        public Examination GetById(int id)
        {
            return _examinationRepository.GetById(id);
        }

        public void Update(Examination entity)
        {
            throw new NotImplementedException();
        }
    }
}
