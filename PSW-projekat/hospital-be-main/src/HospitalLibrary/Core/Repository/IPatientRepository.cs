﻿using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        public Patient RegisterPatient(Patient patient);
        public Person getPersonByPatientId(int id);
        public IEnumerable<Doctor> GetAllDoctors();
        public void AddAllergyToPatient(Patient patient, List<Allergy> allergies);
        public Patient getPatientByPersonId(int id);
        public IEnumerable<Allergy> GetAllAllergiesForPatient(int id);
    }
}
