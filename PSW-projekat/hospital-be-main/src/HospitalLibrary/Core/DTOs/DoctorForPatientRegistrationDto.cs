using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTOs
{
    public class DoctorForPatientRegistrationDto
    {
        [Required]
        public int Id { get; set; }
        [Required][MaxLength(30)]
        public String FullName { get; set; }
    }
}
