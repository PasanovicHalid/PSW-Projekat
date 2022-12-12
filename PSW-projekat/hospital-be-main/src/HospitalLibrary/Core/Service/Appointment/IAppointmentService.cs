using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.DTOs.CreatingAppointmentsDTOs;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public interface IAppointmentService : IService<Appointment>
    {
        IEnumerable<AppointmentDto> GetAllByDoctor(int doctorId);
        void Update(AppointmentDto appointmentDto);
        void SentEmail(Appointment appointment);
        List<AppointmentsAvailableForCreatingAppointment> GetAllAvailableAppointmentsForCreatingAppointment(
            CheckAvailableAppontmentDto checkAvailableAppontment
            );
    }
}
