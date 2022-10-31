using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTOs
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime DateTime { get; set; }
        public UserDto Patinet { get; set; }
        public UserDto Doctor { get; set; }
    }
}
