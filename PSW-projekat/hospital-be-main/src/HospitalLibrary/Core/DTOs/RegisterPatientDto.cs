using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.DTOs
{
    public class RegisterPatientDto
    {
        [Required][MaxLength(30)]
        public String Name { get; set; }
        [Required][MaxLength(30)]
        public String Surname { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public String BirthDate { get; set; }
        [Required][EmailAddress]
        public String Email { get; set; }
        [Required][MaxLength(30)]
        public String Street { get; set; }
        [Required][MaxLength(30)]
        public String Number { get; set; }
        [Required][MaxLength(30)]
        public String City { get; set; }
        [Required][MaxLength(30)]
        public String Township { get; set; }
        [Required][MaxLength(30)]
        public String PostCode { get; set; }
        [Required][MaxLength(30)]
        public String Username { get; set; }
        [Required][MaxLength(30)]
        public String Password { get; set; }
        [Required]
        public BloodType BloodType { get; set; }
        public List<Allergy> Allergies { get; set; }
        [Required]
        public SimpleDoctorDto DoctorName { get; set; }
        [Required][StringLength(13)]
        public String Jmbg { get; set; }

    }
}
