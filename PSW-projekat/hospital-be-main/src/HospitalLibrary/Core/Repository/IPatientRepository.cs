using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        public Patient RegisterPatient(Patient patient);
        public Person getPersonByPatientId(int id);
        IEnumerable<PatientAllergies> GetAllPatientAllergies();
        IEnumerable<int> GetAllDoctorsWhoHavePatients();
        int GetByAgeAndDoctor(DateTime dateTime1, DateTime dateTime2, int id);
    }
}
