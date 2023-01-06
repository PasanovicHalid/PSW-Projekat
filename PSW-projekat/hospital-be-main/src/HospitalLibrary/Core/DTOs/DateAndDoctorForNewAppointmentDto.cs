using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTOs
{
    public class DateAndDoctorForNewAppointmentDto
    {
        public int DoctorId { get; set; }
        public DateTime ScheduledDate { get; set; }

        public DateAndDoctorForNewAppointmentDto() { }

        public DateAndDoctorForNewAppointmentDto(int doctorId, DateTime dateTime )
        {
            DoctorId = doctorId;
            ScheduledDate = dateTime;
        }
    }
}
