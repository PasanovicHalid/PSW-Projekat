using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTOs
{
    public class ScheduleAppointmentDto
    {
        public DateTime DateTime { get; set; }
        public int PatientId { get; set; }
        public SimpleDoctorDto Doctor { get; set; }

        public ScheduleAppointmentDto() { }
        public ScheduleAppointmentDto(DateTime dateTime, int patientId, SimpleDoctorDto doctor)
        {
            DateTime = dateTime;
            PatientId = patientId;
            Doctor = doctor;
        }

    }
}
