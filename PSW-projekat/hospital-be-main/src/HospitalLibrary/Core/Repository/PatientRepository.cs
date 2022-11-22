using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDbContext _context;

        public PatientRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Patients.Select(p => p.Doctor).Distinct().ToList();
        }

        public IEnumerable<Doctor> GetAllDoctors2()
        {
            return _context.Patients.Select(p => p.Doctor);
        }

        public Patient GetById(int id)
        {
            return _context.Patients.Where(d => d.Id == id).FirstOrDefault();
        }

        public void Update(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Patient RegisterPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return patient;
        }
        
        public Person getPersonByPatientId(int id)
        {
            var patient = _context.Patients.FirstOrDefault(d => d.Id == id);
            var person = _context.Persons.FirstOrDefault(d => d.Id == patient.Person.Id);
            return person;
        }
         
         
        public void AddAllergyToPatient(Patient patient, List<Allergy> allergies)
        {
            foreach (Allergy allergy in allergies)
            {
                PatientAllergies patientAllergies = new PatientAllergies()
                {
                    PatientId = patient.Id,
                    AllergyId = allergy.Id,
                    Deleted = false
                };
                _context.PatientAllergies.Add(patientAllergies);
                _context.SaveChanges();
            }
        }

        public Patient getPatientByPersonId(int id)
        {
            var patient = _context.Patients.FirstOrDefault(d => d.Person.Id == id);
            return patient;
        }

        public IEnumerable<Allergy> GetAllAllergiesForPatient(int id)
        {
            var allergiesIds = _context.PatientAllergies.Where(p => p.PatientId == id).Select(a => a.AllergyId);
            var allergies = _context.Allergies.Where(a => allergiesIds.Contains(a.Id));
            return allergies;
        }
    }
}
