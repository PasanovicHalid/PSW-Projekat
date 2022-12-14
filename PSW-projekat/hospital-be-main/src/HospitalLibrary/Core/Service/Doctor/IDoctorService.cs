﻿using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public interface IDoctorService : IService<Doctor>
    {
        AllergiesAndDoctorsForPatientRegistrationDto GetAllergiesAndDoctors();
        Doctor RegisterDoctor(Doctor doctor);
        public Person getPersonByDoctorId(int id);
        IEnumerable<DoctorsCouncilDto> GetAllCouncilByDoctor(int doctorId);
    }
}
