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
        private readonly ISymptomRepository _symptomRepository;
        private readonly IMedicineRepository _medicineRepository;


        public ExaminationService(IExaminationRepository examinationRepository, ISymptomRepository symptomRepository, IMedicineRepository medicineRepository)
        {
            _examinationRepository = examinationRepository;
            _symptomRepository = symptomRepository;
            _medicineRepository = medicineRepository;
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

        public List<Symptom> GetHelpSymptoms(Examination examination)
        {
            List<Symptom> pomocniSimptomi = new List<Symptom>();
            foreach (Symptom simptom in examination.Symptoms)
            {
                Symptom pomocniSimptom = new Symptom();
                pomocniSimptom = _symptomRepository.GetById(simptom.Id);
                pomocniSimptomi.Add(pomocniSimptom);
            }
            return pomocniSimptomi;
        }

        public List<Medicine> GetHelpMedicines(Prescription prescription)
        {
            List<Medicine> pomocniLekovi = new List<Medicine>();
            foreach (Medicine medicine in prescription.Medicines)
            {
                Medicine pomocniLek = new Medicine();
                pomocniLek = _medicineRepository.GetById(medicine.Id);
                pomocniLekovi.Add(pomocniLek);
            }
            return pomocniLekovi;
        }

    }
}
