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
            IEnumerable<Person> allDoctors = _personRepository.GetAllDoctors();
            //IEnumerable<Patient> allPatients = _personRepository.GetAllPatients();
            IEnumerable<Allergy> allAllergies = _allergyRepository.GetAll();
            AllergiesAndDoctorsForPatientRegistrationDto allergiesAndDoctors = new AllergiesAndDoctorsForPatientRegistrationDto();

            foreach (var doctor in allDoctors)
            {
                DoctorForPatientRegistrationDto dto = new DoctorForPatientRegistrationDto()
                {
                    Id = doctor.Id,
                    FullName = doctor.Name + " " + doctor.Surname
                };
                allergiesAndDoctors.Doctors.Add(dto);
            }
            allergiesAndDoctors.Allergies = allAllergies.ToList();

            return allergiesAndDoctors;
        }

        public Person getPersonByDoctorId(int id)
        {
            return _doctorRepository.getPersonByDoctorId(id);
        }

        public Doctor RegisterDoctor(Doctor doctor)
        {
            return _doctorRepository.RegisterDoctor(doctor);
        }
    }
}
