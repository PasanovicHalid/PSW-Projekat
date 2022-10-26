using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Appointment: BaseModel
    {
        public int AppointmentId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
