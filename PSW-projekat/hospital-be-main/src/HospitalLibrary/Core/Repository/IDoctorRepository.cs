using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        public Person getPersonByDoctorId(int id);
        Doctor RegisterDoctor(Doctor doctor);
    }
}
