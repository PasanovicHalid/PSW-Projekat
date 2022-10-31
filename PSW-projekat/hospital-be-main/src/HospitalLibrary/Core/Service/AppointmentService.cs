using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void Create(Appointment entity)
        {
            entity.Deleted = false;
            _appointmentRepository.Create(entity);
        }

        public void Delete(Appointment entity)
        {
            string fromMail = "radisa.stojkic@gmail.com";
            string fromPassword = "pblclisovitnnlfz";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress("radisa.stojkic@gmail.com"));
            message.Body = "<html><body> Termin za pregled je odlozen. </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);

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

        public IEnumerable<AppointmentDto> GetAllByDoctor(int doctorId)
        {
            IEnumerable<Appointment> allAppointments = _appointmentRepository.GetAllByDoctor(doctorId);
            List<AppointmentDto> appointmentsDtos = new();

            foreach (Appointment appointment in allAppointments)
            {
                AppointmentDto appointmentDto = new AppointmentDto();
                UserDto patientDto = new UserDto();
                patientDto.Name = appointment.Patient.Name;
                patientDto.Surname = appointment.Patient.Surname;

                UserDto doctorDto = new UserDto();
                doctorDto.Name = appointment.Doctor.Name;
                doctorDto.Surname = appointment.Doctor.Surname;

                appointmentDto.Patinet = patientDto;
                appointmentDto.Doctor = doctorDto;
                appointmentDto.DateTime = appointment.DateTime;

                appointmentsDtos.Add(appointmentDto);

            }
            return appointmentsDtos;
            
        }


    }
}
