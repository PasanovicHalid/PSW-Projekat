using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Appointment: BaseModel
    {
        public int Id { get; set; }
        public String PatientId { get; set; }
        public String DoctorId { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public String Email { get; set; }
    }
}
