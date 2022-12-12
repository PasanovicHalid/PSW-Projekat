

using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace HospitalLibrary.Core.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly HospitalDbContext _context;

        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.ToList();          
        }

        public IEnumerable<Appointment> GetAllByDoctor(int doctorId)
        {
            return _context.Appointments.Include(x => x.Doctor).Include(x => x.Patient)
                .Where(x => x.Doctor.Id == doctorId && !x.Deleted).ToList();
        }

        public Appointment GetById(int id)
        {
            return _context.Appointments.Find(id);
        }

        public void Create(Appointment room)
        {
            _context.Appointments.Add(room);
            _context.SaveChanges();
        }

        public void Update(Appointment room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                _context.Update(room);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        public void Delete(Appointment room)
        {
            _context.Appointments.Remove(room);
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetAllByDoctorInDateRange(
            int doctorId,
            DateTime fromDate,
            DateTime toDate
        )
        {
            return _context.Appointments.Include(x => x.Doctor).Include(x => x.Patient)
                .Where(x => x.Doctor.Id == doctorId && !x.Deleted && fromDate <= x.DateTime && x.DateTime < toDate).ToList();
        }

        public IEnumerable<Appointment> GetAllByPatientInDateRange(
            int patientId,
            DateTime fromDate,
            DateTime toDate
        )
        {
            return _context.Appointments.Include(x => x.Doctor).Include(x => x.Patient)
                .Where(x => x.Patient.Id == patientId && !x.Deleted && fromDate <= x.DateTime && x.DateTime < toDate).ToList();
        }
    }
}
