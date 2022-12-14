using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetAllByDoctor(int doctorId);
        IEnumerable<DateTime> GetAllFreeByDoctor(int doctorId,DateTime start, DateTime end);
        IEnumerable<DateTime> GetAllFree(ICollection<Doctor> doctors, DateTime start, DateTime end);
    }
}
