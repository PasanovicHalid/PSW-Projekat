using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int minPatients = GetAll().ToList().Min(pNum => pNum.Patients.Count());
            return _context.Doctors.Where(d => d.Patients.Count() <= minPatients + 2);
        }

        public Doctor GetById(int id)
        {
             return _context.Doctors.Where(d => d.Id == id).FirstOrDefault();
        }


        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
