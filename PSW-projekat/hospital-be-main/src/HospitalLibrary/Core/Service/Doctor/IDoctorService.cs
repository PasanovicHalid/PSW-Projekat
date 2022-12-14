using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.DTOs.CreatingAppointmentsDTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public interface IDoctorService : IService<Doctor>
    {
        AllergiesAndDoctorsForPatientRegistrationDto GetAllergiesAndDoctors();
        Doctor RegisterDoctor(Doctor doctor);
        public Person getPersonByDoctorId(int id);
        public List<DoctorForCreatingAppointmentDto> GetAllDoctorsForCreatingAppointment();
        IEnumerable<Doctor> GetAllBySpecialization(Specialization specialization);
    }
}
