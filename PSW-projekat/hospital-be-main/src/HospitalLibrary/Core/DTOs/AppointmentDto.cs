using System;

namespace HospitalLibrary.Core.DTOs
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime DateTime { get; set; }
        public PatientDto Patient { get; set; }
        public DoctorDto Doctor { get; set; }

        public AppointmentDto() { }
        public AppointmentDto(int appointmentId, DateTime dateTime, PatientDto patient, DoctorDto doctor)
        {
            AppointmentId = appointmentId;
            DateTime = dateTime;
            Patient = patient;
            Doctor = doctor;
        }
    }
}
