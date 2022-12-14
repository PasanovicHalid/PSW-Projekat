using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalDbContext _context;

        public DoctorRepository(HospitalDbContext context)
        {
            _context = context;
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
            return _context.Doctors.ToList();
        }

        
        public IEnumerable<Doctor> GetAllDoctorsForPatientRegistration()
        {
            int minPatients = _context.Doctors.ToList().Min(pNum => pNum.Patients.Count());

            return _context.Doctors.Where(d => d.Patients.Count() <= minPatients + 2 && d.Specialization == Specialization.general).ToList();
        }
        

        public Doctor GetById(int id)
        {
             return _context.Doctors.Where(d => d.Id == id).FirstOrDefault();
        }

        public Person getPersonByDoctorId(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            var person = _context.Persons.FirstOrDefault(d => d.Id == doctor.Person.Id);
            return person;
        }

        public Doctor RegisterDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorsCouncil> GetAllCouncilByDoctor(int doctorId)
        {
            return this.GetById(doctorId).Councils;

        }

        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(Specialization specialization)
        {
            return _context.Doctors.Where(d => d.Specialization == specialization).ToList();

        }
    }
}
