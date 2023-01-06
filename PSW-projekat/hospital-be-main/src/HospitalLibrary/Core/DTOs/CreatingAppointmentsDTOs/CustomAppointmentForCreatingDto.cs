using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HospitalLibrary.Core.DTOs.CreatingAppointmentsDTOs
{
    public class CustomAppointmentForCreatingDto
    {
        public string DoctorID { get; set; }
        public string PersonID { get; set; }
        public string CreateDate { get; set; }
    }
}
