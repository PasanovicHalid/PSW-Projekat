using HospitalAPI.DTO;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Adapters
{
    public class DoctorsCouncilAdapter 
    { 
        public static DoctorsCouncil FromDTO(DoctorCouncilDTO testCase)
        {
            Doctor d = new Doctor();
            d.Id = testCase.DoctorId;
            ICollection<Doctor> doctors = new List<Doctor>();
            foreach (DoctorDto doctor in testCase.Doctors) {
                Doctor newDoctor  = new Doctor();
                newDoctor.Id = doctor.Id;
                doctors.Add(newDoctor);
            }

            return new DoctorsCouncil()
            {
                Id = 0,
                Doctor = d,
                Topic = testCase.Topic,
                Start = testCase.Start,
                End = testCase.End,
                Duration = testCase.Duration,
                Doctors = doctors,
                Specializations = testCase.Specializations
            };
        }

    }
}
