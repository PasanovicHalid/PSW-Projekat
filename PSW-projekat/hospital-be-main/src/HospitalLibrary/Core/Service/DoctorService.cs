using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly DoctorRepository _doctorRepository;
        private readonly PersonRepository _personRepository;
        private readonly AllergyRepository _allergyRepository;

        public DoctorService(DoctorRepository doctorRepository, PersonRepository personRepository, AllergyRepository allergyRepository)
        {
            _doctorRepository = doctorRepository;
            _personRepository = personRepository;
            _allergyRepository = allergyRepository;
        }

        public void Create(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetById(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public AllergiesAndDoctorsForPatientRegistrationDto GetAllergiesAndDoctors()
        {
            AllergiesAndDoctorsForPatientRegistrationDto allergiesAndDoctors = new AllergiesAndDoctorsForPatientRegistrationDto();
            allergiesAndDoctors.Allergies = _allergyRepository.GetAll().ToList();
            allergiesAndDoctors.Doctors = new List<DoctorForPatientRegistrationDto>();
            List<Doctor> allDoctors = _doctorRepository.GetAllDoctorsForPatientRegistration().ToList();
            List<Person> allDoctorsPersonalInforamtion = _personRepository.GetAllDoctors().ToList();

            foreach (var doctor in allDoctorsPersonalInforamtion)
            {
                foreach(var availableDoctor in allDoctors)
                {
                    if(doctor.Id == availableDoctor.Person.Id)
                    {
                        DoctorForPatientRegistrationDto dto = new DoctorForPatientRegistrationDto()
                        {
                            Id = doctor.Id,
                            FullName = doctor.Name + " " + doctor.Surname
                        };
                        allergiesAndDoctors.Doctors.Add(dto);
                        //mala optimizacija
                        if (allergiesAndDoctors.Doctors.Count() == allDoctors.Count())
                        {
                            return allergiesAndDoctors;
                        }
                    }
                }
            }
            return allergiesAndDoctors;
        }
    }
}
