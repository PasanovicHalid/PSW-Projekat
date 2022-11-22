using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;

namespace HospitalLibrary.Core.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetAllDoctors();
        IEnumerable<Person> GetAllPatients();
        public int GetByAgeAndGender(DateTime to, DateTime from, Gender gender);
        Person RegisterUser(Person person);
        IEnumerable<Person> GetAllDoctorsForPatientRegistration(List<int> allDoctorsIds);
    }
}
