using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTOs
{
    public class PatientAppointmentsDto
    {
        public int AppointmentId { get; set; }
        public String DoctorFullName { get; set; }
        public DateTime AppointmentTime { get; set; }
        public String AppointmentStatus { get; set; }
    }
}
