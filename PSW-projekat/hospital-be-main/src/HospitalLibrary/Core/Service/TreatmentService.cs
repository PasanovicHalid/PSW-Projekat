using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;

        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;

        }
        public void Create(Treatment treatment)
        {
            treatment.Deleted = false;
            treatment.TreatmentState.Equals("open");

            _treatmentRepository.Create(treatment);
        }

        public void Delete(Treatment treatment)
        {
            treatment.Deleted = true;
            _treatmentRepository.Delete(treatment);
        }

        public IEnumerable<Treatment> GetAll()
        {
            return _treatmentRepository.GetAll();
        }

        public Treatment GetById(int id)
        {
            return _treatmentRepository.GetById(id);
        }

        public void Update(Treatment treatment)
        {
            treatment.Deleted = false;
           // treatment.TreatmentState.Equals("close");
            

            _treatmentRepository.Update(treatment);
        }
    }
}
