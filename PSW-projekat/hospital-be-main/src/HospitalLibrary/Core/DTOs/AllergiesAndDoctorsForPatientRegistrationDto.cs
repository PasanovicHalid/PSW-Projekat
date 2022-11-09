using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTOs
{
    public class AllergiesAndDoctorsForPatientRegistrationDto
    {
        public List<Allergy> allergies;
        public List<Doctor> doctors;
    }
}
