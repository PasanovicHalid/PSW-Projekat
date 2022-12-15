using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.DTOs
{
    public class SimpleDoctorDto
    {
        [Required]
        public int Id { get; set; }
        [Required][MaxLength(30)]
        public String FullName { get; set; }
    }
}
