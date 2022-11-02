using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IAppointmentService : IService<Appointment>
    {
        IEnumerable<AppointmentDto> GetAllByDoctor(int doctorId);
        void Update(AppointmentDto appointmentDto);
    }
}
