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
        public Room Room { get; set; }
        public List<WorkingDay> WorkingTime { get; set; }
    }
}
