using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IPatientService : IService<Patient>
    {
        Patient RegisterPatient(Patient patient);
        //public Person getPersonByPatientId(int id);
        public IEnumerable<Patient> GetPatientsNoTreatment();
        
        public void AddAllergyToPatient(Patient patient, List<Allergy> allergies);
        IEnumerable<Allergy> GetAllAllergiesForPatient(int id);

        public Patient getPatientByPersonId(int id);

    }
}
