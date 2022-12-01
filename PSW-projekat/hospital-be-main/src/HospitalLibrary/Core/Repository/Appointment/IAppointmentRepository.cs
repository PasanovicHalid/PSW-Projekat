using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetAllByDoctor(int doctorId);
        IEnumerable<Appointment> GetAllForPatient(int patientId);
        IEnumerable<Patient> GetAllMaliciousPatients();
    }
}
