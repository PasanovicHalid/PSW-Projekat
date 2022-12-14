using System.Collections.Generic;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IPersonService : IService<Person>
    {
        IEnumerable<Person> GetAllDoctors();
        IEnumerable<Person> GetAllPatients();
        Person RegisterPerson(Person person);
    }
}
