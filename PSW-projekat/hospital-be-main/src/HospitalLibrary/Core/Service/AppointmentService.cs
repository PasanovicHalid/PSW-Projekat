using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentService : IService<Appointment>
    {
        private readonly IRepository<Appointment> _appointmentRepository;

        public AppointmentService(IRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void Create(Appointment entity)
        {
            _appointmentRepository.Create(entity);
        }

        public void Delete(Appointment entity)
        {
            _appointmentRepository.Delete(entity);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public void Update(Appointment entity)
        {
            _appointmentRepository.Update(entity);
        }
    }
}
