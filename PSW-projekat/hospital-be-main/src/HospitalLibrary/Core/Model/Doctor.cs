using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Doctor : User 
    {
        public int DoctorId { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public virtual List<WorkingDay> WorkingTime { get; set; }
    }
}
